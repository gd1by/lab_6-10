package pr_1;

public class task117117 {

	public static void main(String[] args) {

			int i;
			int j;
			for (i = 1; i < 10; i++)
			{
			for (j = 1; j < 10; j++)
			{
				System.out.print(i);
				System.out.print("*");
				System.out.print(j);
				System.out.print(" = ");
				System.out.printf("%d", (i * j));
				System.out.printf("%d", " (");
				System.out.printf("%x", i * j);
				System.out.printf("%x", ") ");
				System.out.printf("%x", "\n");
			}
			}

	}

}
