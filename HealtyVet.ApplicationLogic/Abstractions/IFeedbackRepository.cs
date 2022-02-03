using HealtyVet.ApplicationLogic.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealtyVet.ApplicationLogic.Abstractions
{
    public interface IFeedbackRepository : IRepository<Feedback>
    {
        Feedback GetFeedbackById(Guid feedbackId);
    }
}
