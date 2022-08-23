namespace TaskMap1.Models
{
    internal interface IEquipmentRepository
    {
        System.Collections.Generic.IEnumerable<Equipment> GetAll { get; }
    }
}