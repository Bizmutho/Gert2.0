using Modulos.Credito.clases;
using Modulos.Modelos;
using Moratorios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modulos
{
    public partial class Captura_Credito : Form
    {
        List<(int, String)> socios;
        List<(int, String)> sociosFiltrados;
        List<(int, String)> paisesNac;
        List<(int, String)> estadosNac;
        List<(int, String)> municipiosNac;
        List<(int, String)> localidadesNac;
        List<(int, String)> paises;
        List<(int, String)> estados;
        List<(int, String)> municipios;
        List<(int, String)> localidades;
        List<(int, String)> actividades;
        List<(int, String)> oficiales;
        List<(int, String)> fondeadores;
        Captura_Contrato_Controller ccc;

        public Captura_Credito()
        {
            ccc = new Captura_Contrato_Controller();
            InitializeComponent();

            StartPosition = FormStartPosition.CenterScreen;

            dtpFcaInicio.Format = DateTimePickerFormat.Custom;
            dtpFcaInicio.CustomFormat = "dd/MM/yyyy";
            dtpFcaNac.Format = DateTimePickerFormat.Custom;
            dtpFcaNac.CustomFormat = "dd/MM/yyyy";

            llenarDropBoxs();
        }

        public void llenarDropBoxs()
        {
            socios = ccc.listas("listaSocios","");
            sociosFiltrados = socios;
            cbSocios.Items.Add("Nuevo Socio");

            if (socios != null)
            {
                socios.ForEach(item =>
                {
                    cbSocios.Items.Add(item.Item2);
                });
            }

            paises = ccc.listas("listaPaises", "");

            paisesNac = paises;

            cbPaisNac.Items.Add("Seleccione un pais");
            cbPais.Items.Add("Seleccione un pais");

            paises.ForEach(item =>
            {
                cbPaisNac.Items.Add(item.Item2);
                cbPais.Items.Add(item.Item2);
            });

            cbEstadoNac.Items.Add("Seleccione un pais");
            cbMunicipioNac.Items.Add("Seleccione un estado");
            cbLocalidadNac.Items.Add("Seleccione un municipio");

            cbEstado.Items.Add("Seleccione un pais");
            cbMunicipio.Items.Add("Seleccione un estado");
            cbLocalidad.Items.Add("Seleccione un municipio");

            actividades = ccc.listas("listaActividades", "");

            cbActividades.Items.Add("Seleccione una actividad");

            actividades.ForEach(item =>
            {
                cbActividades.Items.Add(item.Item2);
            });

            oficiales = ccc.listas("listaOficiales", "");

            cbOficiales.Items.Add("Seleccione un oficial");

            oficiales.ForEach(item =>
            {
                cbOficiales.Items.Add(item.Item2);
            });

            fondeadores = ccc.listas("listaFondeadores", "");

            cbFondeadores.Items.Add("Seleccione un fondeador");

            fondeadores.ForEach(item =>
            {
                cbFondeadores.Items.Add(item.Item2);
            });

            cbActividades.SelectedIndex = 0;
            cbPaisNac.SelectedIndex = 0;
            cbEstadoNac.SelectedIndex = 0;
            cbMunicipioNac.SelectedIndex = 0;
            cbLocalidadNac.SelectedIndex = 0;
            cbPais.SelectedIndex = 0;
            cbEstado.SelectedIndex = 0;
            cbMunicipio.SelectedIndex = 0;
            cbLocalidad.SelectedIndex = 0;
            cbSocios.SelectedIndex = 0;
            cbOficiales.SelectedIndex = 0;
            cbFondeadores.SelectedIndex = 0;
        }

        private void cbSocios_Leave(object sender, EventArgs e)
        {

        }

        private void cbSocios_TextUpdate(object sender, EventArgs e)
        {
            String txt = cbSocios.Text.ToLower();

            cbSocios.Items.Clear();

            cbSocios.Items.Add("Nuevo Socio");

            sociosFiltrados = socios.FindAll(socio => socio.Item2.ToLower().Contains(txt));

            sociosFiltrados.ForEach(socio => {
                cbSocios.Items.Add(socio.Item2);
            });

            cbSocios.DroppedDown = true;

            cbSocios.IntegralHeight = false;

            cbSocios.SelectedIndex = -1;

            cbSocios.Text = txt;

            cbSocios.SelectionStart = txt.Length;

            cbSocios.SelectionLength = 0;

            cbSocios.DropDownHeight = 150;
        }

        private void cbSocios_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSocios.SelectedIndex == 0)
            {
                Campos(true);
            } else
            {
                ccc.informacionSocio(sociosFiltrados[cbSocios.SelectedIndex-1].Item1);
                Campos(false);
            }
        }

        public void Campos(Boolean estado)
        {
            txbNombres.Enabled = estado;
            txbNombres.Text = estado ? "" : CreditoInfo.Nombres;
            txbPaterno.Enabled = estado;
            txbPaterno.Text = estado ? "" : CreditoInfo.Paterno;
            txbMaterno.Enabled = estado;
            txbMaterno.Text = estado ? "" : CreditoInfo.Materno;
            dtpFcaNac.Enabled = estado;
            dtpFcaNac.Value = estado ? DateTime.Now : CreditoInfo.FcaNac;
            cbSexo.Enabled = estado;
            cbSexo.SelectedIndex = estado ? 0 : CreditoInfo.Sexo;
            txbCurp.Enabled = estado;
            txbCurp.Text = estado ? "" : CreditoInfo.Curp;
            txbRFC.Enabled = estado;
            txbRFC.Text = estado ? "" : CreditoInfo.RFC;
            txbINE.Enabled = estado;
            txbINE.Text = estado ? "" : CreditoInfo.INE;
            txbCelular.Enabled = estado;
            txbCelular.Text = estado ? "" : CreditoInfo.Celular;
            txbTelefono.Enabled = estado;
            txbTelefono.Text = estado ? "" : CreditoInfo.Telefono;
            cbPaisNac.Enabled = estado;
            cbPaisNac.SelectedIndex = estado ? 0 : CreditoInfo.PaisNac;
            cbEstadoNac.Enabled = estado;
            if (estado)
            {
                cbEstadoNac.SelectedIndex = 0;
            } else
            {
                cbEstadoNac.SelectedIndex = estadosNac.FindIndex(item => item.Item1 == CreditoInfo.EstadoNac) + 1;
            }

            cbMunicipioNac.Enabled = estado;
            if (estado)
            {
                cbMunicipioNac.SelectedIndex = 0;
            }
            else
            {
                cbMunicipioNac.SelectedIndex = municipiosNac.FindIndex(item => item.Item1 == CreditoInfo.MunicipioNac) + 1;
            }

            cbLocalidadNac.Enabled = estado;
            if (estado)
            {
                cbLocalidadNac.SelectedIndex = 0;
            }
            else
            {
                cbLocalidadNac.SelectedIndex = localidadesNac.FindIndex(item => item.Item1 == CreditoInfo.LocalidadNac) + 1;
            }

            cbEstadoCivil.Enabled = estado;
            cbEstadoCivil.SelectedIndex = estado ? 0 : CreditoInfo.EstadoCivil;
            txbCorreo.Enabled = estado;
            txbCorreo.Text = estado ? "" : CreditoInfo.Correo;
            cbPais.Enabled = estado;
            cbPais.SelectedIndex = estado ? 0 : CreditoInfo.Pais;
            cbEstado.Enabled = estado;
            if (estado)
            {
                cbEstado.SelectedIndex = 0;
            }
            else
            {
                cbEstado.SelectedIndex = estados.FindIndex(item => item.Item1 == CreditoInfo.Estado) + 1;
            }

            cbMunicipio.Enabled = estado;
            if (estado)
            {
                cbMunicipio.SelectedIndex = 0;
            }
            else
            {
                cbMunicipio.SelectedIndex = municipios.FindIndex(item => item.Item1 == CreditoInfo.Municipio) + 1;
            }

            cbLocalidad.Enabled = estado;
            if (estado)
            {
                cbLocalidad.SelectedIndex = 0;
            }
            else
            {
                cbLocalidad.SelectedIndex = localidades.FindIndex(item => item.Item1 == CreditoInfo.Localidad) + 1;
            }

            txbColonia.Enabled = estado;
            txbColonia.Text = estado ? "" : CreditoInfo.Colonia;
            txbDireccion.Enabled = estado;
            txbDireccion.Text = estado ? "" : CreditoInfo.Direccion;
            txbNoInterior.Enabled = estado;
            txbNoInterior.Text = estado ? "" : CreditoInfo.NoInterior;
            txbNoExterior.Enabled = estado;
            txbNoExterior.Text = estado ? "" : CreditoInfo.NoExterior;
            txbCodigoPostal.Enabled = estado;
            txbCodigoPostal.Text = estado ? "" : CreditoInfo.CodigoPostal;
            cbEstudios.Enabled = estado;
            cbEstudios.SelectedIndex = estado ? 0 : CreditoInfo.Estudios;
            cbActividades.Enabled = estado;
            cbActividades.SelectedIndex = estado ? 0 : CreditoInfo.Actividades;
            txbDescripcionActividad.Enabled = estado;
            txbDescripcionActividad.Text = estado ? "" : CreditoInfo.DescripcionActividad;
        }

        private void cbPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPais.SelectedIndex != 0)
            {
                cbEstado.Items.Clear();
                estados = new List<(int, String)>();

                estados = ccc.listas("listaEstados", "" + paises[cbPais.SelectedIndex-1].Item1);

                cbEstado.Items.Add("Seleccione un estado");

                estados.ForEach(item => {
                    cbEstado.Items.Add(item.Item2);
                });

                cbEstado.SelectedIndex = 0;
            }
        }

        private void cbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstado.SelectedIndex != 0)
            {
                cbMunicipio.Items.Clear();
                municipios = new List<(int, String)>();

                municipios = ccc.listas("listaMunicipios", "" + estados[cbEstado.SelectedIndex - 1].Item1);

                cbMunicipio.Items.Add("Seleccione un municipio");

                municipios.ForEach(item => {
                    cbMunicipio.Items.Add(item.Item2);
                });

                cbMunicipio.SelectedIndex = 0;
            }
        }

        private void cbMunicipio_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMunicipio.SelectedIndex != 0)
            {
                cbLocalidad.Items.Clear();
                localidades = new List<(int, String)>();

                localidades = ccc.listas("listaLocalidades", "" + municipios[cbMunicipio.SelectedIndex - 1].Item1);

                cbLocalidad.Items.Add("Seleccione una localidad");

                localidades.ForEach(item => {
                    cbLocalidad.Items.Add(item.Item2);
                });

                cbLocalidad.SelectedIndex = 0;
            }
        }

        private void cbPaisNac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbPaisNac.SelectedIndex != 0)
            {
                cbEstadoNac.Items.Clear();
                estadosNac = new List<(int, String)>();

                estadosNac = ccc.listas("listaEstados", "" + paisesNac[cbPaisNac.SelectedIndex - 1].Item1);

                cbEstadoNac.Items.Add("Seleccione un estado");

                estadosNac.ForEach(item => {
                    cbEstadoNac.Items.Add(item.Item2);
                });

                cbEstadoNac.SelectedIndex = 0;
            }
        }

        private void cbEstadoNac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbEstadoNac.SelectedIndex != 0)
            {
                cbMunicipioNac.Items.Clear();
                municipiosNac = new List<(int, String)>();

                municipiosNac = ccc.listas("listaMunicipios", "" + estadosNac[cbEstadoNac.SelectedIndex - 1].Item1);

                cbMunicipioNac.Items.Add("Seleccione un municipio");

                municipiosNac.ForEach(item => {
                    cbMunicipioNac.Items.Add(item.Item2);
                });

                cbMunicipioNac.SelectedIndex = 0;
            }
        }

        private void cbMunicipioNac_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMunicipioNac.SelectedIndex != 0)
            {
                cbLocalidadNac.Items.Clear();
                localidadesNac = new List<(int, String)>();

                localidadesNac = ccc.listas("listaLocalidades", "" + municipiosNac[cbMunicipioNac.SelectedIndex - 1].Item1);

                cbLocalidadNac.Items.Add("Seleccione una localidad");

                localidadesNac.ForEach(item => {
                    cbLocalidadNac.Items.Add(item.Item2);
                });

                cbLocalidadNac.SelectedIndex = 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbSocios.SelectedIndex == 0)
            {
                if (camposCorrectos())
                {
                    CreditoInfo.Nombres = txbNombres.Text.ToUpper();
                    CreditoInfo.Paterno = txbPaterno.Text.ToUpper();
                    CreditoInfo.Materno = (txbMaterno.Text.ToUpper() != "N/A") ? txbMaterno.Text.ToUpper() : "";
                    CreditoInfo.FcaNac = dtpFcaNac.Value;
                    CreditoInfo.Sexo = cbSexo.SelectedIndex;
                    CreditoInfo.Curp = txbCurp.Text.ToUpper();
                    CreditoInfo.RFC = txbRFC.Text.ToUpper();
                    CreditoInfo.INE = txbINE.Text.ToUpper();
                    CreditoInfo.Telefono = txbTelefono.Text;
                    CreditoInfo.Celular = txbCelular.Text;
                    CreditoInfo.PaisNac = paisesNac[cbPaisNac.SelectedIndex - 1].Item1;
                    CreditoInfo.EstadoNac = estadosNac[cbEstadoNac.SelectedIndex - 1].Item1;
                    CreditoInfo.MunicipioNac = municipiosNac[cbMunicipioNac.SelectedIndex - 1].Item1;
                    CreditoInfo.LocalidadNac = localidadesNac[cbLocalidadNac.SelectedIndex - 1].Item1;
                    CreditoInfo.EstadoCivil = cbEstadoCivil.SelectedIndex;
                    CreditoInfo.Correo = txbCorreo.Text;
                    CreditoInfo.Pais = paises[cbPais.SelectedIndex - 1].Item1;
                    CreditoInfo.Estado = estados[cbEstado.SelectedIndex - 1].Item1;
                    CreditoInfo.Municipio = municipios[cbMunicipio.SelectedIndex - 1].Item1;
                    CreditoInfo.Localidad = localidades[cbLocalidad.SelectedIndex - 1].Item1;
                    CreditoInfo.Colonia = txbColonia.Text.ToUpper();
                    CreditoInfo.Direccion = txbDireccion.Text.ToUpper();
                    CreditoInfo.NoExterior = txbNoExterior.Text.ToUpper();
                    CreditoInfo.NoInterior = txbNoInterior.Text.ToUpper();
                    CreditoInfo.CodigoPostal = txbCodigoPostal.Text;
                    CreditoInfo.Estudios = cbEstudios.SelectedIndex;
                    CreditoInfo.Actividades = cbActividades.SelectedIndex;
                    CreditoInfo.DescripcionActividad = txbDescripcionActividad.Text.ToUpper();
                    CreditoInfo.Oficial = oficiales[cbOficiales.SelectedIndex - 1].Item1;
                    CreditoInfo.Fondeador = fondeadores[cbFondeadores.SelectedIndex - 1].Item1;
                    CreditoInfo.Monto = Convert.ToDouble(txbMonto.Text);
                    CreditoInfo.Pagos = Convert.ToInt32(txbPagos.Text);
                    CreditoInfo.IVA = Convert.ToDouble(txbIVA.Text);
                    CreditoInfo.Tasa = Convert.ToDouble(txbTasa.Text);
                    CreditoInfo.FcaInicio = dtpFcaInicio.Value;
                    CreditoInfo.Aval1Nombre = txbAval1Nombre.Text.ToUpper();
                    CreditoInfo.Aval1INE = txbAval1INE.Text.ToUpper();
                    CreditoInfo.Aval1Telefono = txbAval1Telefono.Text.ToUpper();
                    CreditoInfo.Aval1Direccion = txbAval1Direccion.Text.ToUpper();
                    CreditoInfo.Aval2Nombre = (!txbAval2Nombre.Text.Equals("")) ? txbAval2Nombre.Text.ToUpper() : "NULL";
                    CreditoInfo.Aval2INE = (!txbAval2INE.Text.Equals("")) ? txbAval2INE.Text.ToUpper() : "NULL";
                    CreditoInfo.Aval2Telefono = (!txbAval2Telefono.Text.Equals("")) ? txbAval2Telefono.Text.ToUpper() : "NULL";
                    CreditoInfo.Aval2Direccion = (!txbAval2Direccion.Text.Equals("")) ? txbAval2Direccion.Text.ToUpper() : "NULL";

                    if (ccc.insertarPrestamo_Persona()) {
                        MessageBox.Show("Prestamo insertado correctamente");
                        Inicio ini = new Inicio();
                        ini.Show();
                        this.Dispose();
                    } else
                    {
                        MessageBox.Show("Error al insertar el credito");
                    }
                }
            } else
            {
                if (camposCorrectos())
                {
                    CreditoInfo.idSocio = socios[ cbSocios.SelectedIndex - 1 ].Item1;
                    CreditoInfo.Oficial = oficiales[cbOficiales.SelectedIndex - 1].Item1;
                    CreditoInfo.Fondeador = fondeadores[cbFondeadores.SelectedIndex - 1].Item1;
                    CreditoInfo.Monto = Convert.ToDouble(txbMonto.Text);
                    CreditoInfo.Pagos = Convert.ToInt32(txbPagos.Text);
                    CreditoInfo.IVA = Convert.ToDouble(txbIVA.Text);
                    CreditoInfo.Tasa = Convert.ToDouble(txbTasa.Text);
                    CreditoInfo.FcaInicio = dtpFcaInicio.Value;
                    CreditoInfo.Aval1Nombre = txbAval1Nombre.Text.ToUpper();
                    CreditoInfo.Aval1INE = txbAval1INE.Text.ToUpper();
                    CreditoInfo.Aval1Telefono = txbAval1Telefono.Text.ToUpper();
                    CreditoInfo.Aval1Direccion = txbAval1Direccion.Text.ToUpper();
                    CreditoInfo.Aval2Nombre = (!txbAval2Nombre.Text.Equals("")) ? txbAval2Nombre.Text.ToUpper() : "NULL";
                    CreditoInfo.Aval2INE = (!txbAval2INE.Text.Equals("")) ? txbAval2INE.Text.ToUpper() : "NULL";
                    CreditoInfo.Aval2Telefono = (!txbAval2Telefono.Text.Equals("")) ? txbAval2Telefono.Text.ToUpper() : "NULL";
                    CreditoInfo.Aval2Direccion = (!txbAval2Direccion.Text.Equals("")) ? txbAval2Direccion.Text.ToUpper() : "NULL";

                    if (ccc.insertarPrestamo())
                    {
                        MessageBox.Show("Prestamo insertado correctamente");
                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("Error al insertar el credito");
                    }
                }
            }
        }

        public bool camposCorrectos()
        {
            bool correcto = true;
            String mensaje = "";
            if (cbSocios.SelectedIndex == 0)
            {
                if (txbNombres.Text == "")
                {
                    txbNombres.BackColor = Color.Red;
                    correcto = false;
                }
                if (txbPaterno.Text == "")
                {
                    txbPaterno.BackColor = Color.Red;
                    correcto = false;
                }
                if (txbMaterno.Text == "")
                {
                    txbMaterno.BackColor = Color.Red;
                    correcto = false;
                }
                if (dtpFcaNac.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                {
                    mensaje += "Ingrese una fecha de nacimiento valida!\n";
                    correcto = false;
                }
                if (txbCurp.Text == "")
                {
                    txbCurp.BackColor = Color.Red;
                    correcto = false;
                }
                if (txbINE.Text == "")
                {
                    txbINE.BackColor = Color.Red;
                    correcto = false;
                }
                if (txbCelular.Text == "")
                {
                    txbCelular.BackColor = Color.Red;
                    correcto = false;
                }
                if (cbLocalidadNac.SelectedIndex == 0)
                {
                    mensaje += "Seleccione una localidad de nacimiento!\n";
                    correcto = false;
                }
                if (cbLocalidad.SelectedIndex == 0)
                {
                    mensaje += "Seleccione una localidad de residencia!\n";
                    correcto = false;
                }
                if (txbColonia.Text == "")
                {
                    txbColonia.BackColor = Color.Red;
                    correcto = false;
                }
                if (txbDireccion.Text == "")
                {
                    txbDireccion.BackColor = Color.Red;
                    correcto = false;
                }
                if (txbNoExterior.Text == "")
                {
                    txbNoExterior.BackColor = Color.Red;
                    correcto = false;
                }
                if (txbCodigoPostal.Text == "")
                {
                    txbCodigoPostal.BackColor = Color.Red;
                    correcto = false;
                }
                if (cbActividades.SelectedIndex == 0)
                {
                    mensaje += "Seleccione una actividad!\n";
                    correcto = false;
                }
                if (txbDescripcionActividad.Text == "")
                {
                    txbDescripcionActividad.BackColor = Color.Red;
                    correcto = false;
                }
            }
            if (cbOficiales.SelectedIndex == 0)
            {
                mensaje += "Seleccione un oficial!\n";
                correcto = false;
            }
            if (cbFondeadores.SelectedIndex == 0)
            {
                mensaje += "Seleccione un fondeador!\n";
                correcto = false;
            }
            if (txbMonto.Text == "")
            {
                txbMonto.BackColor = Color.Red;
                correcto = false;
            }
            if (txbPagos.Text == "")
            {
                txbPagos.BackColor = Color.Red;
                correcto = false;
            }
            if(txbIVA.Text == "")
            {
                txbIVA.BackColor = Color.Red;
                correcto = false;
            }
            if (txbTasa.Text == "")
            {
                txbTasa.BackColor = Color.Red;
                correcto = false;
            }
            if (dtpFcaInicio.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                mensaje += "Ingrese una fecha de inicio valida!\n";
                correcto = false;
            }
            if (txbAval1Nombre.Text == "")
            {
                txbAval1Nombre.BackColor = Color.Red;
                correcto = false;
            }
            if (txbAval1INE.Text == "")
            {
                txbAval1INE.BackColor = Color.Red;
                correcto = false;
            }
            if (txbAval1Telefono.Text == "")
            {
                txbAval1Telefono.BackColor = Color.Red;
                correcto = false;
            }
            if (txbAval1Direccion.Text == "")
            {
                txbAval1Direccion.BackColor = Color.Red;
                correcto = false;
            }

            if (!correcto && mensaje != "")
            {
                MessageBox.Show(mensaje, "Error al capturar los datos.");
            }

            return correcto;
        }

        private void txbNombres_Enter(object sender, EventArgs e)
        {
            txbNombres.BackColor = Color.White;
        }

        private void txbPaterno_Enter(object sender, EventArgs e)
        {
            txbPaterno.BackColor = Color.White;
        }

        private void txbMaterno_Enter(object sender, EventArgs e)
        {
            txbMaterno.BackColor = Color.White;
        }

        private void txbCurp_Enter(object sender, EventArgs e)
        {
            txbCurp.BackColor = Color.White;
        }

        private void txbINE_Enter(object sender, EventArgs e)
        {
            txbINE.BackColor = Color.White;
        }

        private void txbCelular_Enter(object sender, EventArgs e)
        {
            txbCelular.BackColor = Color.White;
        }

        private void txbColonia_Enter(object sender, EventArgs e)
        {
            txbColonia.BackColor = Color.White;
        }

        private void txbDireccion_Enter(object sender, EventArgs e)
        {
            txbDireccion.BackColor = Color.White;
        }

        private void txbNoExterior_Enter(object sender, EventArgs e)
        {
            txbNoExterior.BackColor = Color.White;
        }

        private void txbCodigoPostal_Enter(object sender, EventArgs e)
        {
            txbCodigoPostal.BackColor = Color.White;
        }

        private void txbDescripcionActividad_Enter(object sender, EventArgs e)
        {
            txbDescripcionActividad.BackColor = Color.White;
        }

        private void txbMonto_Enter(object sender, EventArgs e)
        {
            txbMonto.BackColor = Color.White;
        }

        private void txbPagos_Enter(object sender, EventArgs e)
        {
            txbPagos.BackColor = Color.White;
        }

        private void txbIVA_Enter(object sender, EventArgs e)
        {
            txbIVA.BackColor = Color.White;
        }

        private void txbTasa_Enter(object sender, EventArgs e)
        {
            txbTasa.BackColor = Color.White;
        }

        private void txbAval1Nombre_Enter(object sender, EventArgs e)
        {
            txbAval1Nombre.BackColor = Color.White;
        }

        private void txbAval1INE_Enter(object sender, EventArgs e)
        {
            txbAval1INE.BackColor = Color.White;
        }

        private void txbAval1Telefono_Enter(object sender, EventArgs e)
        {
            txbAval1Telefono.BackColor = Color.White;
        }

        private void txbAval1Direccion_Enter(object sender, EventArgs e)
        {
            txbAval1Direccion.BackColor = Color.White;
        }

        private void cbOficiales_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
