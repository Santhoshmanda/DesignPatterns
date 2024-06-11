using System;
namespace Design_Patterns.Behavioral.TemplateMethod
{

	public abstract class Recipe
	{
        public abstract void PrepareIngredients();
        public abstract void CookIngredients();
        public abstract void Serve();
       

        public void Cook()
		{
			PrepareIngredients();
			CookIngredients();
			Serve();
        }

	
	}

    public class CookRice : Recipe
    {
        public override void CookIngredients()
        {
            
        }

        public override void PrepareIngredients()
        {
            
        }

        public override void Serve()
        {
            
        }
    }

    public class CookPulses : Recipe
    {
        public override void CookIngredients()
        {

        }

        public override void PrepareIngredients()
        {

        }

        public override void Serve()
        {

        }
    }
}

