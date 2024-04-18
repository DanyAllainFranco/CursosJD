import 'dart:convert';

import 'package:flutter/material.dart';
import 'package:http/http.dart' as http;

class Categorias extends StatefulWidget {
  const Categorias({Key? key}) : super(key: key);

  @override
  State<Categorias> createState() => _CategoriasState();
}

class _CategoriasState extends State<Categorias> {
  String url = 'https://localhost:44392/API/Usuario/List';

  Future<List<dynamic>> _getListado() async {
    final result = await http.get(Uri.parse(url));

    if (result.statusCode == 200) {
      // Parsea la respuesta JSON
      final jsonResponse = jsonDecode(result.body);
      print(jsonResponse);
      // Verifica si la respuesta contiene una lista bajo una clave específica
      if (jsonResponse is List) {
        return jsonResponse;
      } else {
        // Si la respuesta no es una lista, puedes retornar una lista vacía o lanzar una excepción
        // En este ejemplo, retornaremos una lista vacía
        return [];
      }
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
        builder: (context, snapshot) {
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
      columns: const [
        DataColumn(label: Text('ID')),
        DataColumn(label: Text('Usuario')),
        DataColumn(label: Text('Nombre')),
        DataColumn(label: Text('Apellido')),
        DataColumn(label: Text('Fecha de Nacimiento')),
        DataColumn(label: Text('Sexo')),
        DataColumn(label: Text('Dirección')),
        DataColumn(label: Text('Teléfono')),
        DataColumn(label: Text('Correo Electrónico')),
      ],
      rows: data.map((item) {
        return DataRow(
          cells: [
            DataCell(Text(item['usu_Id'].toString())),
            DataCell(Text(item['usu_Usuario'])),
            DataCell(Text(item['usu_Nombre'])),
            DataCell(Text(item['usu_Apellido'])),
            DataCell(Text(item['usu_FechaNacimiento'])),
            DataCell(Text(item['usu_Sexo'])),
            DataCell(Text(item['usu_Direccion'])),
            DataCell(Text(item['usu_Telefono'].toString())),
            DataCell(Text(item['usu_CorreoElectronico'])),
          ],
        );
      }).toList(),
    ),
  );
}
}
