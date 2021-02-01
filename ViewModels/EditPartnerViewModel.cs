using Flunt.Notifications;
using Flunt.Validations;

namespace Cotabox.ViewModels
{
  public class EditPartnerViewModel: Notifiable, IValidatable
  {
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public decimal Participation { get; set; }

    public void Validate()
    {
      AddNotifications(
        new Contract()
          .HasMaxLen(FirstName, 20, "FirstName", "O primeiro nome deve ter até 20 caracteres")
          .HasMinLen(FirstName, 2, "FirstName", "O primeiro nome deve ter no mínimo 2 caracteres")
          .HasMaxLen(LastName, 20, "LastName", "O sobrenome deve ter até 20 caracteres")
          .HasMinLen(LastName, 2, "LastName", "O sobrenome deve ter no mínimo 2 caracteres")
          .IsGreaterThan(Participation, 0, "Participation", "A participação deve ser maior do que zero")
          .IsLowerOrEqualsThan(Participation, 100, "Participation", "A participação não pode ser maior do que 100")
      );
    }
  }
}