﻿using System.ComponentModel.DataAnnotations.Schema;

namespace UserCRUDApi.Domain;

public class BaseModel
{
    [Column("id")]
    public long Id { get; set; }
}