
import 'dart:convert';

import 'package:flutter/material.dart';

import 'package:http/http.dart' as http;

class MyWidget extends StatefulWidget {
  const MyWidget({super.key});

  @override
  State<MyWidget> createState() => _MyWidgetState();
}
//Future
//Final
//Dynamic
class _MyWidgetState extends State<MyWidget> {
  String url = "https://localhost:44392/API/Usuario/List";

  Future<dynamic> _getListado() async{
    final resultado = await http.get(Uri.parse(url));
    if (resultado.statusCode == 200) {
    return jsonDecode(resultado.body);
  }else {
    print("Error en el endPoint");
  }
   }
  @override
  Widget build(BuildContext context) {
    return Scaffold(
    appBar: AppBar(
      title: const Text("Listado API"),
    ),
    body: FutureBuilder<dynamic>( 
        future: _getListado(),
        builder: (context,snapshot){
          if(snapshot.hasData){
            var listOfData = snapshot.data as List<dynamic>;
             return SingleChildScrollView(
              scrollDirection: Axis.vertical,
              child: SingleChildScrollView(
                scrollDirection: Axis.horizontal,
                child: DataTable(
                  columns: const [
                    DataColumn(label: Text('ID')),
                    DataColumn(label: Text('Usuario')),

                  ],
                  rows: 
                      listOfData.map(
                        (usuario) => DataRow(cells: [
                          DataCell(Text(usuario['usu_Id'].toString())),
                          DataCell(Text(usuario['usu_Usuario'])),
                          // Agrega aquí más DataCell para más datos
                        ]),
                      )
                      .toList(),
                ),
              ),
            );
          }else{
            return Center(child: CircularProgressIndicator());
          }
        },
            ),
    );
  }
  List<Widget> listado(List<dynamic>? info){
  List<Widget> lista = [];
  if(info!= null){
    info.forEach((element) {
      lista.add(Text(element["usu_Usuario"]));
    });

  }
  return lista;
}
}

