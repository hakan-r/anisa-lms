using anisa_lms.Data;
using anisa_lms.DTOs;
using anisa_lms.Interfaces;
using anisa_lms.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace anisa_lms.Services
{
    public class ModuleService(AppDbContext context, IMapper mapper) : IModuleService
    {
        private readonly AppDbContext _context = context;
        private readonly IMapper _mapper = mapper;

        public async Task CreateAsync(CreateModuleDto create)
        {
            var module = _mapper.Map<Module>(create);

            await _context.Modules.AddAsync(module);
            await _context.SaveChangesAsync();
        }

        public async Task<bool?> DeleteAsync(Guid mId)
        {
            var module = await _context.Modules.FirstOrDefaultAsync(m => m.Id == mId);
            if (module == null) return null;

            _context.Modules.Remove(module);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool?> UpdateAsync(Guid mId, UpdateModuleDto update)
        {
            var module = await _context.Modules.FirstOrDefaultAsync(m => m.Id == mId);
            if (module == null) return null;

            _mapper.Map(update, module);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
