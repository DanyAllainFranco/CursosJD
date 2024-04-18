import 'dart:convert';
import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class MyWidget extends StatefulWidget {
  const MyWidget({Key? key}) : super(key: key);

  @override
  State<MyWidget> createState() => _MyWidgetState();
}

class _MyWidgetState extends State<MyWidget> {
  String url = 'https://localhost:44392/API/Usuario/List';

  late Future<List<dynamic>> _getListado;
  bool _isSortAsc = true;
  // ignore: unused_field
  int _currentSortColumn = 0;

  @override
  void initState() {
    super.initState();
    _getListado = _fetchData();
  }

  Future<List<dynamic>> _fetchData() async {
    final http.Response result = await http.get(Uri.parse(url));
    // ignore: always_specify_types
    final jsonData = jsonDecode(result.body);
    // ignore: always_specify_types
    final dataList = jsonData['data']; // Extraer la lista de objetos JSON
    return dataList as List<dynamic>; // Devolver la lista de objetos JSON
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text("Listado Usuarios"),
        backgroundColor: const Color.fromARGB(123, 131, 34, 211),
        centerTitle: true,
        elevation: 0,
      ),
      body: FutureBuilder<List<dynamic>>(
        future: _getListado,
        // ignore: always_specify_types
        builder: (BuildContext context, snapshot) {
          if (snapshot.connectionState == ConnectionState.waiting) {
            return const Center(child: CircularProgressIndicator());
          } else if (snapshot.hasData) {
            return Center(
              child: Container(
                width: MediaQuery.of(context).size.width * 0.8, // Ancho del contenedor
                margin: const EdgeInsets.all(20),
                padding: const EdgeInsets.all(20),
                decoration: BoxDecoration(
                  color: const Color.fromARGB(71, 104, 46, 128), // Fondo blanco crema para el contenedor
                  borderRadius: BorderRadius.circular(10), // Bordes redondeados
                ),
                child: SingleChildScrollView(
                  child: PaginatedDataTable(
                    header: const Text('Listado Usuarios', style: TextStyle(fontWeight: FontWeight.bold, fontSize: 20)),
                    rowsPerPage: 5,
                    columns: <DataColumn>[
                      DataColumn(
                        label: const Text('ID'),
                        onSort: (int columnIndex, _) {
                          setState(() {
                            _currentSortColumn = columnIndex;
                            if (_isSortAsc) {
                              // ignore: always_specify_types
                              snapshot.data!.sort((a, b) => b['usu_Id'].compareTo(a['usu_Id']));
                            } else {
                              // ignore: always_specify_types
                              snapshot.data!.sort((a, b) => a['usu_Id'].compareTo(b['usu_Id']));
                            }
                            _isSortAsc = !_isSortAsc;
                          });
                        },
                      ),
                                            DataColumn(
                        label: const Text('Usuario'),
                        onSort: (int columnIndex, _) {
                          setState(() {
                            _currentSortColumn = columnIndex;
                            if (_isSortAsc) {
                              // ignore: always_specify_types
                              snapshot.data!.sort((a, b) => b['usu_Usuario'].compareTo(a['usu_Usuario']));
                            } else {
                              // ignore: always_specify_types
                              snapshot.data!.sort((a, b) => a['usu_Usuario'].compareTo(b['usu_Usuario']));
                            }
                            _isSortAsc = !_isSortAsc;
                          });
                        },
                      ),
                                            DataColumn(
                        label: const Text('Admin'),
                        onSort: (int columnIndex, _) {
                          setState(() {
                            _currentSortColumn = columnIndex;
                            if (_isSortAsc) {
                              // ignore: always_specify_types
                              snapshot.data!.sort((a, b) => b['usu_Admin'].compareTo(a['usu_Admin']));
                            } else {
                              // ignore: always_specify_types
                              snapshot.data!.sort((a, b) => a['usu_Admin'].compareTo(b['usu_Admin']));
                            }
                            _isSortAsc = !_isSortAsc;
                          });
                        },
                      ),
                    ],
                    source: _DataSource(snapshot.data!),
                    showCheckboxColumn: false,
                    columnSpacing: 10, // Espacio entre las columnas
                  ),
                ),
              ),
            );
          } else if (snapshot.hasError) {
            return Center(child: Text('Error: ${snapshot.error}'));
          } else {
            return const Center(child: Text('No hay datos disponibles'));
          }
        },
      ),
    );
  }
}

class _DataSource extends DataTableSource {
  final List<dynamic> _data;

  _DataSource(this._data);

  @override
  DataRow? getRow(int index) {
    if (index >= _data.length) return null;
    // ignore: always_specify_types
    final row = _data[index];
    return DataRow(
      color: MaterialStateProperty.resolveWith<Color>((Set<MaterialState> states) {
        return index % 2 == 0 ? Colors.grey[200]! : Colors.transparent;
      }), // Color de fondo alternado para filas
      cells: <DataCell>[
        DataCell(Text(row["usu_Id"].toString())),
        DataCell(Text(row["usu_Usuario"])),
        DataCell(Text(row["usu_Admin"].toString())),
      ],
    );
  }

  @override
  bool get isRowCountApproximate => false;

  @override
  int get rowCount => _data.length;

  @override
  int get selectedRowCount => 0;
}

void main() {
  runApp(MaterialApp(
    title: 'Flutter Demo',
    theme: ThemeData(
      primarySwatch: Colors.blue,
      scaffoldBackgroundColor: Colors.grey[200], // Fondo gris claro para el Scaffold
    ),
    home: const MyWidget(),
  ));
}