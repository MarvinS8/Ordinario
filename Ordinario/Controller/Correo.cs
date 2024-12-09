using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net;

namespace Ordinario.Controller
{
    public class Correo
    {
        public void EnviarCorreoConfirmacion(string destinatario, string nombre, DateTime fechaNacimiento, string tel)
        {
            string asunto = "Registro Exitoso";
            string mensaje = $"Hola {nombre},\n\nTu registro ha sido exitoso. Aquí están tus detalles:\n" +
                             $"Nombre: {nombre}\n" +
                             $"Correo Electrónico: {destinatario}\n" +
                             $"Fecha de Nacimiento: {fechaNacimiento.ToShortDateString()}\n" +
                             $"Teléfono: {tel}\n\n" +
                             "Gracias por registrarte.";

            Enviar(destinatario, asunto, mensaje);
        }

        private void Enviar(string destinatario, string asunto, string mensaje)
        {
            MailMessage correo = new MailMessage
            {
                From = new MailAddress("112240@alumnouninter.mx"), // Reemplazar con tu correo
                Subject = asunto,
                Body = mensaje,
            };
            correo.To.Add(destinatario);

            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587)
            {
                Credentials = new NetworkCredential("112240@alumnouninter.mx", "#Mar$aid2"), // Credenciales correctas
                EnableSsl = true
            };

            smtp.Send(correo);
        }
        public void EnviarCorreoConPDF(string destinatario, string nombre, DateTime fechaNacimiento, string telefono, string pdfPath)
        {
            string asunto = "Resumen de tu Compra";
            string mensaje = $"Hola {nombre},\n\nGracias por tu compra. Aquí tienes el resumen de tu compra adjunto.\n" +
                             $"Fecha de Nacimiento: {fechaNacimiento.ToShortDateString()}\n" +
                             $"Teléfono: {telefono}\n\nGracias por elegirnos.";

            MailMessage correo = new MailMessage
            {
                From = new MailAddress("112240@alumnouninter.mx"),
                Subject = asunto,
                Body = mensaje
            };
            correo.To.Add(destinatario);

            // Adjuntar PDF
            Attachment attachment = new Attachment(pdfPath);
            correo.Attachments.Add(attachment);

            SmtpClient smtp = new SmtpClient("smtp.office365.com", 587)
            {
                Credentials = new NetworkCredential("112240@alumnouninter.mx", "#Mar$aid2"),
                EnableSsl = true
            };
            smtp.Send(correo);
        }

    }

}