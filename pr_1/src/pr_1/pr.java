package pr_1;
/* 67. Одноклеточное животное амёба каждые 3 часа делится на 2 клетки. Определить, сколько клеток 
 * будет через 3, 6, 9,..., 24 часа, если первоначально была одна амёба.*/
public class pr {
	public static void main (String args []) {
        int s=1;
         for(int i=3;i<24;i+=3){
         s*=2;
        System. out. println ("Chasov"+i);
        System. out. println ("Ameb"+s);
		} 
	}

}
