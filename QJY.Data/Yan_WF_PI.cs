
//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------


namespace QJY.Data
{

using System;
    using System.Collections.Generic;
    
public partial class Yan_WF_PI
{

    public Nullable<int> ComId { get; set; }

    public int ID { get; set; }

    public string Description { get; set; }

    public Nullable<int> PDID { get; set; }

    public Nullable<System.DateTime> StartTime { get; set; }

    public Nullable<int> StartTaskInstanceID { get; set; }

    public string RelatedTable { get; set; }

    public string WFFormNum { get; set; }

    public string isComplete { get; set; }

    public Nullable<System.DateTime> CompleteTime { get; set; }

    public string IsSuspended { get; set; }

    public Nullable<System.DateTime> SuspendedTime { get; set; }

    public string IsCanceled { get; set; }

    public Nullable<System.DateTime> CanceledTime { get; set; }

    public string CanceledReason { get; set; }

    public string Remark1 { get; set; }

    public string CRUser { get; set; }

    public Nullable<System.DateTime> CRDate { get; set; }

    public string PITYPE { get; set; }

    public string ChaoSongUser { get; set; }

}

}
