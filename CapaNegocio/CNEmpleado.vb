Imports CapaEntidad
Imports CapaDatos
Public Class CNEmpleado

    Dim DatosEmpleado As New CDEmpleado()

    Public Function ValidarDatos(ByVal empleado As CEEmpleado) As Boolean
        Dim Resultado As Boolean = True

        If empleado.Nombre = "" Then
            Resultado = False
            MessageBox.Show("El Nombre es Obligatorio")
        End If

        If empleado.Apellido = "" Then
            Resultado = False
            MessageBox.Show("El Apellido es Obligatorio")
        End If

        Return Resultado
    End Function

    Public Sub PruebaMysql()
        DatosEmpleado.ProbarConexion()
    End Sub

    Public Sub Insertar(ByVal empleado As CEEmpleado)
        DatosEmpleado.Insertar(empleado)
    End Sub

    Public Sub Editar(ByVal empleado As CEEmpleado)
        DatosEmpleado.Modificar(empleado)
    End Sub

    Public Sub Eliminar(ByVal empleado As CEEmpleado)

        If MessageBox.Show("¿Estas Seguro?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            DatosEmpleado.Eliminar(empleado)
        End If

    End Sub

    Public Function Listar() As DataSet
        Return DatosEmpleado.Listar()
    End Function

End Class
