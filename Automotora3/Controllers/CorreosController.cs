using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Automotora3.Data;
using Automotora3.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
namespace Automotora3.Controllers
{
    public class CorreosController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CorreosController(ApplicationDbContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Correo.ToListAsync());
        }

      
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id, from, to, body")] Correo emailObject)
        {

            MailMessage Correo = new MailMessage();

            Correo.From = new MailAddress(emailObject.from, "zek", System.Text.Encoding.UTF8);
            Correo.To.Add("zek.rodriguez.v@gmail.com");
            Correo.Subject = "Solicito Información";
            Correo.Body = emailObject.body;
            Correo.IsBodyHtml = true;
            Correo.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.UseDefaultCredentials = false;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new System.Net.NetworkCredential("zek.rodriguez.v@gmail.com", "1033Carlos.");
            ServicePointManager.ServerCertificateValidationCallback = delegate (object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; };
            smtp.EnableSsl = true;

            smtp.Send(Correo);
            smtp.Dispose();


            if (ModelState.IsValid)
            {
                emailObject.to = "zek.rodriguez.v@gmail.com";
                _context.Add(emailObject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }

            return View(emailObject);

        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correo = await _context.Correo
                .FirstOrDefaultAsync(m => m.id == id);
            if (correo == null)
            {
                return NotFound();
            }

            return View(correo);
        }
        // GET: Clientes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var correo = await _context.Correo
                .FirstOrDefaultAsync(m => m.id == id);
            if (correo == null)
            {
                return NotFound();
            }

            return View(correo);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var correo = await _context.Correo.FindAsync(id);
            _context.Correo.Remove(correo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CorreoExists(int id)
        {
            return _context.Correo.Any(e => e.id == id);
        }
    }
}
  