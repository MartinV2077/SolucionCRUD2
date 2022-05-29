Imports MySql.Data.MySqlClient
Imports CapaEntidad
Public Class CDEmpleado

    Private _cadenaConexion As String = "Server=127.0.0.1;User=root;Password=Admin123;Port=3306;database=curso_vb"

    Public Sub ProbarConexion()

        Dim Conexion As New MySqlConnection(_cadenaConexion)

        Try
            Conexion.Open()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Exit Sub
        End Try

        MessageBox.Show("Conectado")
        Conexion.Close()


    End Sub

    Public Sub Insertar(ByVal empleado As CEEmpleado)
        Dim Conexion As New MySqlConnection(_cadenaConexion)
        Conexion.Open()
        Dim Query As String = "INSERT INTO `empleados` (`nombre`, `apellido`, `foto`) VALUES ('" & empleado.Nombre & "', '" & empleado.Apellido & "', '" & MySql.Data.MySqlClient.MySqlHelper.EscapeString(empleado.Foto) & "');"
        Dim Comando As New MySqlCommand(Query, Conexion)
        Comando.ExecuteNonQuery()
        Conexion.Close()
        MessageBox.Show("Registro Creado")
    End Sub

    Public Sub Modificar(ByVal empleado As CEEmpleado)
        Dim Conexion As New MySqlConnection(_cadenaConexion)
        Conexion.Open()
        Dim Query As String = "UPDATE `empleados` SET `nombre`='" & empleado.Nombre & "', `apellido`='" & empleado.Apellido & "', `foto`='" & MySql.Data.MySqlClient.MySqlHelper.EscapeString(empleado.Foto) & "' WHERE  `id`=" & empleado.Id & ";"
        Dim Comando As New MySqlCommand(Query, Conexion)
        Comando.ExecuteNonQuery()
        Conexion.Close()
        MessageBox.Show("Registro Editado")
    End Sub

    Public Sub Eliminar(ByVal empleado As CEEmpleado)
        Dim Conexion As New MySqlConnection(_cadenaConexion)
        Conexion.Open()
        Dim Query As String = "DELETE FROM `empleados` WHERE  `id`=" & empleado.Id & ";"
        Dim Comando As New MySqlCommand(Query, Conexion)
        Comando.ExecuteNonQuery()
        Conexion.Close()
        MessageBox.Show("Registro Eliminado")
    End Sub


    Public Function Listar() As DataSet

        Dim Conexion As New MySqlConnection(_cadenaConexion)
        Conexion.Open()
        Dim Query As String = "SELECT * FROM `empleados` LIMIT 1000;"
        Dim Adaptador As MySqlDataAdapter
        Dim dataSet As New DataSet

        Adaptador = New MySqlDataAdapter(Query, Conexion)
        Adaptador.Fill(dataSet, "empleado")

        Return dataSet


    End Function

End Class
