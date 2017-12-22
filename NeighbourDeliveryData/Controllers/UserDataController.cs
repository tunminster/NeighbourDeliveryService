using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Data;
using System.Threading;
using Microsoft.ServiceFabric.Data.Collections;
using NeighbourDelivery.Database;
using NeighbourDelivery.Database.Models;
using NeighbourDelivery.Core.Dtos;
using AutoMapper;

namespace NeighbourDeliveryData.Controllers
{
    [Produces("application/json")]
    [Route("api/UserData")]
    public class UserDataController : Controller
    {
        private readonly IReliableStateManager _stateManager;
        private readonly NdDbContext _ndDbContext;
        private readonly IMapper _mapper;

        public UserDataController(IReliableStateManager stateManager, NdDbContext context, IMapper mapper)
        {
            _stateManager = stateManager;
            _ndDbContext = context;
            _mapper = mapper;
        }

        public async Task<IActionResult> Get()
        {
            CancellationToken ct = new CancellationToken();

            return null;
        }

        // PUT api/UserData/userdto
        [HttpPut("{userDto}")]
        public async Task<IActionResult> Put(UserDto userDto)
        {
            //IReliableDictionary<string, int> votesDictionary = await _stateManager.GetOrAddAsync<IReliableDictionary<string, int>>("counts");

            if (ModelState.IsValid)
            {
                using (ITransaction tx = _stateManager.CreateTransaction())
                {
                    await _ndDbContext.AddAsync<User>(_mapper.Map<User>(userDto));
                    await _ndDbContext.SaveChangesAsync();
                    await tx.CommitAsync();
                    return new OkResult();
                }
            }

            return BadRequest(ModelState);

        }



    }
}