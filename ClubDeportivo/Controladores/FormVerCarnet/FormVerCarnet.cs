using ClubDeportivo.Modelos;
using ClubDeportivo.Servicios;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.IO;
using System.Windows.Forms;

namespace ClubDeportivo.Controladores.FormVerCarnet
{
    public partial class frmVerCarnet : Form
    {
        private readonly int idSocio;

        public frmVerCarnet(int idSocio)
        {
            InitializeComponent();
            this.idSocio = idSocio;
        }

        private void frmVerCarnet_Load(object sender, EventArgs e)
        {
            CargarDatosCarnet();
        }

        private void btnVolverCarnet_Click(object sender, EventArgs e)
        {
            this.Close();
            new ClubDeportivo.Controladores.FormPrincipalSocio.frmPrincipalSocio(idSocio).Show();
        }

        private void CargarDatosCarnet()
        {
            var repo = new SocioRepository();
            Socio socio = repo.VerCarnet(idSocio);

            if (socio != null)
            {
                lblDniCompletoCarnet.Text = socio.Dni;
                lblNombreCompletoCarnet.Text = $"{socio.Nombre} {socio.Apellido}";
                lblFechaNacimientoCompletoCarnet.Text = socio.FechaNacimiento.ToString("dd/MM/yyyy");
                lblFechaAltaCompletoCarnet.Text = socio.FechaAlta.ToString("dd/MM/yyyy");
                lblFichaMedicaCompletoCarnet.Text = socio.FichaMedica ? "Sí" : "No";
            }
            else
            {
                MessageBox.Show("No se encontraron datos del socio.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
            }
        }

        private void btnImprimirCarnet_Click(object sender, EventArgs e)
        {
            var confirmacion = MessageBox.Show(
        "¿Desea generar el carnet en formato PDF?",
        "Confirmar impresión",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                try
                {
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "Archivos PDF (*.pdf)|*.pdf";
                        saveFileDialog.FileName = $"Carnet_{lblNombreCompletoCarnet.Text.Replace(" ", "_")}.pdf";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            GenerarPDFCarnet(saveFileDialog.FileName);
                            MessageBox.Show("Carnet generado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al generar el carnet: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void GenerarPDFCarnet(string rutaArchivo)
        {
            Document doc = new Document(PageSize.A7.Rotate(), 10, 10, 10, 10);
            PdfWriter.GetInstance(doc, new FileStream(rutaArchivo, FileMode.Create));
            doc.Open();

            var titulo = new Paragraph("CLUB DEPORTIVO", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14, iTextSharp.text.Font.BOLD));
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);

            doc.Add(new Paragraph(" "));

            var tabla = new PdfPTable(2);
            tabla.WidthPercentage = 100;

            tabla.AddCell("Nombre:");
            tabla.AddCell(lblNombreCompletoCarnet.Text);

            tabla.AddCell("DNI:");
            tabla.AddCell(lblDniCompletoCarnet.Text);

            tabla.AddCell("Fecha de Nacimiento:");
            tabla.AddCell(lblFechaNacimientoCompletoCarnet.Text);

            tabla.AddCell("Fecha de Alta:");
            tabla.AddCell(lblFechaAltaCompletoCarnet.Text);

            tabla.AddCell("Ficha Médica:");
            tabla.AddCell(lblFichaMedicaCompletoCarnet.Text);

            doc.Add(tabla);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph("Emitido el: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm")));

            doc.Close();
        }
    }
}
