# Lagrangian Interpolation Polynomial Generator

Congratulations! You found a backup article OWO

Simplified Chinese version is in the same directory

___

Lagrangian interpolation polynomial generator 

**There have a better version in my C# Library: [CWKSC/MyLib_Csharp](https://github.com/CWKSC/MyLib_Csharp)**

___

[【Just For Fun】拉格朗日插值多项式生成器 - 知乎](https://zhuanlan.zhihu.com/p/77491558) （Article has been deleted 文章已經刪除）

___

Lagrange interpolation polynomial generator. [What is Lagrangian interpolation polynomial? ](https://en.wikipedia.org/wiki/Lagrange_polynomial)

This program was written in the second year of high school, and the code is horrible.

This time I reverse the order, first look at the actual operation and testing, and put the code at the end.

## ▌Actual operation:

![img](https://pic3.zhimg.com/80/v2-4250605ff526dd0348ba6628f201f842_hd.jpg)

Choose whether the function should be x as the main term or y as the main term. Here, x is generally selected.

![img](https://pic3.zhimg.com/80/v2-4c6cfa41e7d2ee11adfabb839606b0fe_hd.png)

How many points to choose. This point is the point through which the Lagrange interpolation polynomial will pass.

We choose 3 here.

![img](https://pic1.zhimg.com/80/v2-6428b08b30f784b556bceaf84f321884_hd.jpg)

Enter (x, y) for each point, here (1, 3), (3, 7), (0, -2) are used.

![img](https://pic3.zhimg.com/80/v2-a5dfafb2f373427b16b9592a096e369a_hd.png)

Generate formulas.

![img](https://pic4.zhimg.com/80/v2-430fe60b3c955e6230973898e3c3eb6f_hd.jpg)

## ▌Test:

A file named `fxfile.txt` is generated, and the content is the generated Lagrange interpolation polynomial.

```text
(3)*((x-3)/(-2))*((x-0)/(1))+((x-1)/(2))*(7)*((x-0)/(3))+((x-1)/(-1))*((x-3)/(-3))*(-2)
```

Put it in [Graphing Calculator-GeoGebra](https://www.geogebra.org/graphing) to have a look.

![img](https://pic3.zhimg.com/80/v2-5c843b46b1afb61bd2105cbd281bda66_hd.jpg)

Passed through all points perfectly.

## ▌Let's try a little more complicated

Using (2, 7), (0, -9), (3, -3), (4, 6), (-5, 3), (1, 5), (-6, 2), the formula:

```text
(7)*((x-0)/(2))*((x-3)/(-1))*((x-4)/(-2))*((x--5)/(7))*((x-1)/(1))*((x--6)/(8))+((x-2)/(-2))*(-9)*((x-3)/(-3))*((x-4)/(-4))*((x--5)/(5))*((x-1)/(-1))*((x--6)/(6))+((x-2)/(1))*((x-0)/(3))*(-3)*((x-4)/(-1))*((x--5)/(8))*((x-1)/(2))*((x--6)/(9))+((x-2)/(2))*((x-0)/(4))*((x-3)/(1))*(6)*((x--5)/(9))*((x-1)/(3))*((x--6)/(10))+((x-2)/(-7))*((x-0)/(-5))*((x-3)/(-8))*((x-4)/(-9))*(3)*((x-1)/(-6))*((x--6)/(1))+((x-2)/(-1))*((x-0)/(1))*((x-3)/(-2))*((x-4)/(-3))*((x--5)/(6))*(5)*((x--6)/(7))+((x-2)/(-8))*((x-0)/(-6))*((x-3)/(-9))*((x-4)/(-10))*((x--5)/(-1))*((x-1)/(-7))*(2)
```

Put it in [Graphing Calculator-GeoGebra](https://www.geogebra.org/graphing) to have a look.

![img](https://pic2.zhimg.com/80/v2-6bb9304778112ad56eec6a21f9bad311_hd.jpg)看文章最The picture above will be clearer

Pass through all points perfectly.

___

Note that when x/y is the main item, you cannot pick two points that are the same on the x/y coordinates.

For example: (0, 3), (0, 5) (with x as the main item)

(7, 0), (9, 0) (with y as the main term)

We cannot generate a straight line function.

## ▌代码：

The code is written in middle school, and the readability is very low, and there is time to refactor.

```c
#define _CRT_SECURE_NO_WARNINGS

#include <stdio.h>
#include <stdlib.h>

int main() {
	char z;
	int i, t, ptnum, x[30], y[30];
	FILE* pfile;
	pfile = fopen("fxfile.txt", "w");
	if (NULL == pfile) {
		printf("open failure");
		system("pause");
	}
	else {
		printf("starting spawn f(x/y)?\n");
		scanf("%c", &z);
		printf("How many point?");
		scanf("%d", &ptnum);
		for (i = 0; i < ptnum; i++) {
			printf("scanf x[%d]:", i);
			scanf("%d", &x[i]);
			printf("scanf y[%d]:", i);
			scanf("%d", &y[i]);
			printf("\n");
		}
		if (z == 'x') {
			for (t = 0; t < ptnum; t++) {
				for (i = 0; i < ptnum; i++) {
					if (t == i) {
						if (i != ptnum - 1) {
							fprintf(pfile, "(%d)*", y[i]);
							printf("(%d)*", y[i]);
						}
						else {
							fprintf(pfile, "(%d)", y[i]);
							printf("(%d)", y[i]);
						}
					}
					else {
						if (i != ptnum - 1) {
							fprintf(pfile, "((x-%d)/(%d))*", x[i], x[t] - x[i]);
							printf("((x-%d)/(%d))*", x[i], x[t] - x[i]);
						}
						else {
							fprintf(pfile, "((x-%d)/(%d))", x[i], x[t] - x[i]);
							printf("((x-%d)/(%d))", x[i], x[t] - x[i]);
						}
					}
				}
				if (t != ptnum - 1) {
					fprintf(pfile, "+");
					printf("+");
				}
			}
		}
		else if (z == 'y') {
			for (t = 0; t < ptnum; t++) {
				for (i = 0; i < ptnum; i++) {
					if (t == i) {
						if (i != ptnum - 1) {
							fprintf(pfile, "(%d)*", x[i]);
							printf("(%d)*", x[i]);
						}
						else {
							fprintf(pfile, "(%d)", x[i]);
							printf("(%d)", x[i]);
						}
					}
					else {
						if (i != ptnum - 1) {
							fprintf(pfile, "((y-%d)/(%d))*", y[i], y[t] - y[i]);
							printf("((y-%d)/(%d))*", y[i], y[t] - y[i]);
						}
						else {
							fprintf(pfile, "((y-%d)/(%d))", y[i], y[t] - y[i]);
							printf("((y-%d)/(%d))", y[i], y[t] - y[i]);
						}
					}
				}
				if (t != ptnum - 1) {
					fprintf(pfile, "+");
					printf("+");
				}
			}
		}
	}
	system("pause");
}
```

// Terrible. Poorly written.

## ▌May be of interest ?

[【Just For Fun】n 階行列式計算 宏 生成器，四阶行列式的最优展开](https://zhuanlan.zhihu.com/p/77057988)

n-order determinant calculation macro generator, optimal expansion of fourth-order determinant

![img](https://pic2.zhimg.com/80/v2-686d2a84bffe0ccd300a38b15800ec65_hd.jpg)



[【Just For Fun】n 階行列式計算 宏 生成器（重构）](https://zhuanlan.zhihu.com/p/77388741)

n-th order determinant calculation macro generator (refactored)
