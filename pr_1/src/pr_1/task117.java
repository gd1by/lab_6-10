package pr_1;
/* 142.Выведите на экран все четырёхразрядные числа,
 в записи которых нет одинаковых цифр. прошу прощение, перепутал номер задания*/
public class task117 {

	public static void main(String[] args) {

		  int i;
		  int j;
		  int k;
		  int t;
		  for (i = 1; i <= 9; i++)
		  {
			for (j = 0; j <= 9; j++)
			{
			  for (k = 0; (k <= 9) && (i != j); k++)
			  {
				for (t = 0; (t <= 9) && (i != k) && (j != k); t++)
				{
				  if ((i != t) && (j != t) && (k != t))
				  {
					System.out.printf("%d%d%d%d, ", i, j, k, t);
				  }
				}
			  }
			}
		  }
		}
	}

