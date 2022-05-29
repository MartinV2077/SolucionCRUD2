Imports CapaEntidad
Imports CapaNegocio

Public Class frEmpleados

    Dim NegocioEmpleado As New CNEmpleado()
    Private Sub btnNombre_Click(sender As Object, e As EventArgs) Handles btnNombre.Click
        Limpiar()
    End Sub

    Private Sub Limpiar()
        txtId.Value = 0
        txtNombre.Text = ""
        txtApellido.Text = ""
        picFoto.Image = Nothing

    End Sub

    Private Sub lnkFoto_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnkFoto.LinkClicked

        openFoto.ShowDialog()
        If openFoto.FileName <> "" Then
            picFoto.Load(openFoto.FileName)
        End If

        openFoto.FileName = ""

    End Sub

    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click

        Dim empleado As New CEEmpleado()
        Dim Validacion As Boolean

        empleado.Id = txtId.Value
        empleado.Nombre = txtNombre.Text
        empleado.Apellido = txtApellido.Text
        empleado.Foto = picFoto.ImageLocation

        Validacion = NegocioEmpleado.ValidarDatos(empleado)
        If Validacion = False Then Exit Sub

        If empleado.Id = 0 Then
            NegocioEmpleado.Insertar(empleado)
        Else
            NegocioEmpleado.Editar(empleado)
        End If


        CargarGrid()
        Limpiar()

    End Sub

    Private Sub btnEliminar_Click(sender As Object, e As EventArgs) Handles btnEliminar.Click
        If txtId.Value = 0 Then Exit Sub

        Dim empleado As New CEEmpleado()
        empleado.Id = txtId.Value
        NegocioEmpleado.Eliminar(empleado)
        CargarGrid()
        Limpiar()

    End Sub

    Private Sub frEmpleados_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarGrid()

    End Sub

    Private Sub CargarGrid()
        gridDatos.DataSource = NegocioEmpleado.Listar().Tables("empleado")
    End Sub


    Private Sub gridDatos_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles gridDatos.CellDoubleClick

        txtId.Value = gridDatos.CurrentRow.Cells("id").Value
        txtNombre.Text = gridDatos.CurrentRow.Cells("nombre").Value
        txtApellido.Text = gridDatos.CurrentRow.Cells("apellido").Value

        If gridDatos.CurrentRow.Cells("foto").Value <> "" Then
            If System.IO.File.Exists(gridDatos.CurrentRow.Cells("foto").Value) Then
                picFoto.Load(gridDatos.CurrentRow.Cells("foto").Value)
            End If
        End If

    End Sub
End Class
