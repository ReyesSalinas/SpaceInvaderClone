
/// Base interface for all weapons 
public interface IWeapon
{
	public Animation Animation {get;set;}
	public Float Cooldown {get;set;}
    public Float Speed {get;set;}
	public Update(GameTime gametTime);
	public Draw(EnitiyObjectBase enityObjcect);

}

public class EnemyWeapon:IWeapon
{
	public EnenmyWeapon()
	{
		Cooldown = Random().Next(1000-5000);
	}	
}

