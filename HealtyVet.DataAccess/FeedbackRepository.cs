using HealtyVet.ApplicationLogic.Abstractions;
using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HealtyVet.DataAccess
{
    public class FeedbackRepository : BaseRepository<Feedback>, IFeedbackRepository
    {

        public FeedbackRepository(HealtyVetDbContext dbContext) : base(dbContext)
        {

        }

        public Feedback GetFeedbackById(Guid feedbackId)
        {
            return dbContext.Feedbacks
                            .Where(feedback => feedback.Id == feedbackId)
                            .FirstOrDefault();
        }


    }
  
}
