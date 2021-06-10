using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paymant.Models;
using paymant.models;

namespace paymant.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymantDetailsController : ControllerBase
    {
        private readonly PaymantDetailContext _context;

        public PaymantDetailsController(PaymantDetailContext context)
        {
            _context = context;
        }

        // GET: api/PaymantDetails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymantDetail>>> GetPaymantDetails()
        {
            return await _context.PaymantDetails.ToListAsync();
        }

        // GET: api/PaymantDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymantDetail>> GetPaymantDetail(int id)
        {
            var paymantDetail = await _context.PaymantDetails.FindAsync(id);

            if (paymantDetail == null)
            {
                return NotFound();
            }

            return paymantDetail;
        }

        // PUT: api/PaymantDetails/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymantDetail(int id, PaymantDetail paymantDetail)
        {
            if (id != paymantDetail.PaymentDetailId)
            {
                return BadRequest();
            }

            _context.Entry(paymantDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymantDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PaymantDetails
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PaymantDetail>> PostPaymantDetail(PaymantDetail paymantDetail)
        {
            _context.PaymantDetails.Add(paymantDetail);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymantDetail", new { id = paymantDetail.PaymentDetailId }, paymantDetail);
        }

        // DELETE: api/PaymantDetails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymantDetail(int id)
        {
            var paymantDetail = await _context.PaymantDetails.FindAsync(id);
            if (paymantDetail == null)
            {
                return NotFound();
            }

            _context.PaymantDetails.Remove(paymantDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaymantDetailExists(int id)
        {
            return _context.PaymantDetails.Any(e => e.PaymentDetailId == id);
        }
    }
}
