﻿using Hookpay.Shared.Domain.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hookpay.Shared.Domain.Models;

public interface IEntity
{    
    public DateTime? CreatedAt { get; set; }
    public int? CreatedBy { get; set; } 
    public DateTime? UpdatedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public bool IsDeleted { get; set; }
}
