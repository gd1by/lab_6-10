package pr_1;
/* 92 Известны оценки по физике каждого из 20 учеников класса. Определить среднюю оценку по классу.*/
public class mainn {

	public static void main(String[] args) {
			int n = 20;
			int[] stud = {4, 5, 4, 4, 3, 5, 3, 5, 3, 5, 5, 3, 1, 4, 5, 2, 5, 4, 4, 3}; 

			float sumA = 0;

			for (int i = 0; i < n; i++)
			{
				sumA += stud[i];
			}

			System.out.print("Average grade in the class: ");
			System.out.print((sumA / n));
	}

}
