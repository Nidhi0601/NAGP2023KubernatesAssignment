using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NAGP2023KubernatesAssignment.Models;

public partial class EmployeeDetail
{
    [Key]
    [Column("EID")]
    public int Eid { get; set; }

    [Column("EName")]
    [StringLength(100)]
    public string? Ename { get; set; }

    [Column("EDesignation")]
    [StringLength(50)]
    public string? Edesignation { get; set; }

    [Column("EScores")]
    public int? Escores { get; set; }
}
