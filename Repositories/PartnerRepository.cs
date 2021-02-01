using System.Collections.Generic;
using System.Threading.Tasks;
using Cotabox.Data;
using Cotabox.Models;
using Cotabox.ViewModels;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;

namespace Cotabox.Repositories
{
  public class PartnerRepository
  {
    private readonly DataContext _context;
    public PartnerRepository(DataContext context)
    {
      _context = context;
    }

    public async Task<ActionResult<List<Partner>>> Get() =>
      await _context.Partner.Find(x => true).ToListAsync();

    public async Task<ActionResult<Partner>> Create(EditPartnerViewModel model)
    {
      // Validar porcentagem

      var partner = new Partner();
      partner.FirstName = model.FirstName;
      partner.LastName = model.LastName;
      partner.Participation = model.Participation;

      await _context.Partner.InsertOneAsync(partner);
      return partner;
    }
  }
}