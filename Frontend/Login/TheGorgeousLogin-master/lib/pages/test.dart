import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class Categorias extends StatefulWidget {
  const Categorias({Key? key}) : super(key: key);

  @override
  State<Categorias> createState() => _CategoriasState();
}

class _CategoriasState extends State<Categorias> {
  String url = 'https://api.thecatapi.com/v1/categories';

  Future<List<dynamic>> _getListado() async {
    final http.Response result = await http.get(Uri.parse(url));

    if (result.statusCode == 200) {
      return jsonDecode(result.body);
    } else {
      throw Exception('Error al obtener los datos');
    }
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: const Text('Listado Categorias'),
      ),
      body: FutureBuilder<List<dynamic>>(
        future: _getListado(),
        // ignore: always_specify_types
        builder: (BuildContext context, snapshot) {
          if (snapshot.hasData) {
            return _buildDataTable(snapshot.data!);
          } else if (snapshot.hasError) {
            return Center(
              child: Text('Error: ${snapshot.error}'),
            );
          } else {
            return const Center(child: CircularProgressIndicator());
          }
        },
      ),
    );
  }

  Widget _buildDataTable(List<dynamic> data) {
    return SingleChildScrollView(
      scrollDirection: Axis.horizontal,
      child: DataTable(
        columns: const <DataColumn>[
          DataColumn(label: Text('Nombre')),
          DataColumn(label: Text('ID')),
        ],
        // ignore: always_specify_types
        rows: data.map((item) {
          return DataRow(
            cells: <DataCell>[
              DataCell(Text(item['name'])),
              DataCell(Text(item['id'].toString())),
            ],
          );
        }).toList(),
      ),
    );
  }
}
