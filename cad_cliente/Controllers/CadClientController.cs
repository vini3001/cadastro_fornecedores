using cad_cliente.Data;
using cad_cliente.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace cad_cliente.Controllers
{
    public class CadClientController : Controller
    {
        public readonly AppCont _appCont;

        public CadClientController(AppCont appCont)
        {
            _appCont = appCont;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create(Client client)
        {
            if (ModelState.IsValid)
            {
                _appCont.Add(client);
                await _appCont.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var client = await _appCont.Clientes.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Name, EndDate, Status")] Client client)
        {
            if (ModelState.IsValid)
            {
                _appCont.Update(client);
                await _appCont.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(client);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _appCont.Clientes.FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var client = await _appCont.Clientes.FindAsync(id);
            _appCont.Clientes.Remove(client);
            await _appCont.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Consult(string socialReason)
        {
            if (socialReason == null)
            {
                return NotFound();
            }

            var client = await _appCont.Clientes.FirstOrDefaultAsync(m => m.SocialReason == socialReason);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }
    }
}
