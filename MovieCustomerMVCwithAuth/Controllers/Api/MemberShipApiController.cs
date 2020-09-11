using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MovieCustomerMVCwithAuth.Models;

namespace MovieCustomerMVCwithAuth.Controllers.Api
{
    public class MemberShipApiController : ApiController
    {
        ApplicationDbContext _context;
        public MemberShipApiController()
        {
            _context = new ApplicationDbContext();
        }
        public IHttpActionResult GetAllMembershipTypes()
        {
            IEnumerable<MemberShipType> membershipTypes;
            membershipTypes = _context.MemberShipTypes.ToList();
            if (membershipTypes == null)
                return NotFound();
            return Ok(membershipTypes);
        }
    }
}
