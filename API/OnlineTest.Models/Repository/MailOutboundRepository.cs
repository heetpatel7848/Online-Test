using OnlineTest.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTest.Models.Repository
{
    public class MailOutboundRepository : IMailOutboundRepository
    {
        #region Fields
        private readonly OnlineTestContext _context;
        #endregion
        #region Constructor
        public MailOutboundRepository(OnlineTestContext context)
        {
            _context = context;
        }
        #endregion
        #region Method
        public int AddMailOutbound(MailOutbound mailOutbound)
        {
            _context.Add(mailOutbound);
            if (_context.SaveChanges() > 0)
                return mailOutbound.Id;
            else
                return 0;
        }
        #endregion
    }
}
