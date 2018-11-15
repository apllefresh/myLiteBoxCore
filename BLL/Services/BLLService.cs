using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Repositories;

namespace BLL.Services
{
    public class BLLService<TBL, TDA> : IBLLService<TBL, TDA>
        where TBL : class where TDA : class
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TDA> _repository;
        private IEnumerable<TBL> _items;

        protected BLLService(IRepository<TDA> repository, IMapper mapper)
        {
            _repository = repository
                          ??
                          throw new ArgumentNullException(nameof(repository));
            _mapper = mapper
                      ??
                      throw new ArgumentNullException(nameof(mapper));
        }

        public virtual async Task<IReadOnlyCollection<TBL>> GetAllItems()
        {
            var items = await _repository.GetAll().ConfigureAwait(false);
            return items.Select(item => _mapper.Map<TBL>(item)).ToArray();
        }

        public virtual async Task<TBL> GetItemById(int id)
        {
            var foundedItem = await _repository.Get(id).ConfigureAwait(false);
            return _mapper.Map<TBL>(foundedItem);
        }

        public virtual async Task Update(TBL item)
        {
            await _repository.Update(_mapper.Map<TDA>(item)).ConfigureAwait(false);
        }

        public virtual async Task Delete(int id) =>
            await _repository.Delete(id).ConfigureAwait(false);

        public virtual async Task Create(TBL item)
        {
            await _repository.Create(_mapper.Map<TDA>(item)).ConfigureAwait(false);
        }
    }
}