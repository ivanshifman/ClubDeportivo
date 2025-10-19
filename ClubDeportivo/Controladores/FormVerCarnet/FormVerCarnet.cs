using ClubDeportivo.Modelos;
using ClubDeportivo.Servicios;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using System;
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
            var socio = new
            {
                Nombre = lblNombreCompletoCarnet.Text,
                Dni = lblDniCompletoCarnet.Text,
                FechaNacimiento = lblFechaNacimientoCompletoCarnet.Text,
                FechaAlta = lblFechaAltaCompletoCarnet.Text,
                FichaMedica = lblFichaMedicaCompletoCarnet.Text
            };

            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A7.Landscape());
                    page.Margin(15);
                    page.DefaultTextStyle(x => x.FontSize(10));

                    page.Content().Column(column =>
                    {
                        column.Spacing(8);

                        column.Item().AlignCenter().Text("CLUB DEPORTIVO")
                            .FontSize(14)
                            .Bold()
                            .FontColor(Colors.Blue.Medium);

                        column.Item().LineHorizontal(0.5f).LineColor(Colors.Grey.Medium);

                        column.Item().Table(table =>
                        {
                            table.ColumnsDefinition(columns =>
                            {
                                columns.ConstantColumn(90);
                                columns.RelativeColumn();
                            });

                            void AddRow(string etiqueta, string valor)
                            {
                                table.Cell().Text(etiqueta).Bold();
                                table.Cell().Text(valor);
                            }

                            AddRow("Nombre:", socio.Nombre);
                            AddRow("DNI:", socio.Dni);
                            AddRow("Fecha Nacimiento:", socio.FechaNacimiento);
                            AddRow("Fecha Alta:", socio.FechaAlta);
                            AddRow("Ficha Médica:", socio.FichaMedica);
                        });

                        column.Item().Text(" ");

                        column.Item().AlignRight().Text($"Emitido el: {DateTime.Now:dd/MM/yyyy HH:mm}")
                            .FontSize(8)
                            .FontColor(Colors.Grey.Darken2);
                    });
                });
            });

            document.GeneratePdf(rutaArchivo);
        }
    }
}