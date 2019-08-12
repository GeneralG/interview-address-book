using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;

namespace ContactManager.Controllers
{
    public class ContactDetailsController : Controller
    {
        private readonly ContactManagerContext _context;

        public ContactDetailsController(ContactManagerContext context)
        {
            _context = context;
        }

        // GET: ContactDetails
        public async Task<IActionResult> Index(int contactId)
        {
            return View(await _context.ContactDetails.Where(e => e.contactId == contactId).ToListAsync());
        }

        // GET: ContactDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetails
                .FirstOrDefaultAsync(m => m.id == id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            return View(contactDetails);
        }

        // GET: ContactDetails/Create
        public IActionResult Create(int contactId)
        {
            ContactDetails cd = new ContactDetails();
            cd.contactId = contactId;
            
            return View(cd);
        }

        // POST: ContactDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,contactItem,contactId")] ContactDetails contactDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index), new { contactId = contactDetails.contactId});
            }
            return View(contactDetails);
        }

        // GET: ContactDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetails.FindAsync(id);
            if (contactDetails == null)
            {
                return NotFound();
            }
            return View(contactDetails);
        }

        // POST: ContactDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,contactItem,contactId")] ContactDetails contactDetails)
        {
            if (id != contactDetails.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactDetailsExists(contactDetails.id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { contactId = contactDetails.contactId });
            }
            return View(contactDetails);
        }

        // GET: ContactDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactDetails = await _context.ContactDetails
                .FirstOrDefaultAsync(m => m.id == id);
            if (contactDetails == null)
            {
                return NotFound();
            }

            return View(contactDetails);
        }

        // POST: ContactDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactDetails = await _context.ContactDetails.FindAsync(id);
            _context.ContactDetails.Remove(contactDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { contactId = contactDetails.contactId});
        }

        private bool ContactDetailsExists(int id)
        {
            return _context.ContactDetails.Any(e => e.id == id);
        }
    }
}
