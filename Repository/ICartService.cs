using TheHealtood.Models;

namespace TheHealtood.Repository;

public interface ICartService
{

    List<Cart> GetAll();
    Cart AddProduct(Cart obj);

    Cart GetCart();

    Cart UpdateCart(Cart obj);

    public void DeleteCart();
}