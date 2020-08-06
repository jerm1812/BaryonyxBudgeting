namespace Budgets.Models
{
    public class SharedBudget
    {
        public int Id { get; set; }
        public int BudgetId { get; set; }
        public ShareType Access { get; set; }
    }
}