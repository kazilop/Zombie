using UnityEngine;

public interface ITriggerCheckable
{
   
    bool isAggres { get; set; }
    bool isInStrikeDistance { get; set; }

    void SetAgroStatus(bool isAggres);
    void SetStrikeDistanceBool(bool isInStrikeDistance);
}
