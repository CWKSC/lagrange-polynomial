# Lagrangian Interpolation Polynomial Generator

Lagrangian interpolation polynomial generator 拉格朗日插值多項式生成器

**There have a better version in my C# Library: [CWKSC/MyLib_Csharp](https://github.com/CWKSC/MyLib_Csharp)**

___

[【Just For Fun】拉格朗日插值多项式生成器 - 知乎](https://zhuanlan.zhihu.com/p/77491558)

___

拉格朗日插值多项式生成器。[什么是拉格朗日插值多项式 ？](https://link.zhihu.com/?target=https%3A//zh.wikipedia.org/zh-cn/%E6%8B%89%E6%A0%BC%E6%9C%97%E6%97%A5%E6%8F%92%E5%80%BC%E6%B3%95)

这个程序是大約是高二写的，代码 [也](https://zhuanlan.zhihu.com/p/77057988) 是惨不忍睹。

这次把次序倒转，先看实际操作、测试，代碼放最後。

## ▌实际操作：

![img](https://pic3.zhimg.com/80/v2-4250605ff526dd0348ba6628f201f842_hd.jpg)

选择函数以 x 为主项还是以 y 为主项，这里一般选 x 。

![img](https://pic3.zhimg.com/80/v2-4c6cfa41e7d2ee11adfabb839606b0fe_hd.png)

选择多少个点。这个点是指拉格朗日插值多项式会穿过的点。

我们这里选 3 个。

![img](https://pic1.zhimg.com/80/v2-6428b08b30f784b556bceaf84f321884_hd.jpg)

输入每个点的 (x, y)，这里用 (1, 3), (3, 7), (0, -2) 。

![img](https://pic3.zhimg.com/80/v2-a5dfafb2f373427b16b9592a096e369a_hd.png)

生成公式。

![img](https://pic4.zhimg.com/80/v2-430fe60b3c955e6230973898e3c3eb6f_hd.jpg)

## ▌测试：

生成了名为 fxfile.txt 的文件，内容就是生成出来的拉格朗日插值多项式。

```text
(3)*((x-3)/(-2))*((x-0)/(1))+((x-1)/(2))*(7)*((x-0)/(3))+((x-1)/(-1))*((x-3)/(-3))*(-2)
```

放到 [图形计算器 - GeoGebra](https://link.zhihu.com/?target=https%3A//www.geogebra.org/graphing) 看看。

![img](https://pic3.zhimg.com/80/v2-5c843b46b1afb61bd2105cbd281bda66_hd.jpg)

完美地穿过了所有点。

## ▌来试一个复杂一点的：

用 (2, 7), (0, -9), (3, -3), (4, 6), (-5, 3), (1, 5), (-6, 2) ，公式：

```text
(7)*((x-0)/(2))*((x-3)/(-1))*((x-4)/(-2))*((x--5)/(7))*((x-1)/(1))*((x--6)/(8))+((x-2)/(-2))*(-9)*((x-3)/(-3))*((x-4)/(-4))*((x--5)/(5))*((x-1)/(-1))*((x--6)/(6))+((x-2)/(1))*((x-0)/(3))*(-3)*((x-4)/(-1))*((x--5)/(8))*((x-1)/(2))*((x--6)/(9))+((x-2)/(2))*((x-0)/(4))*((x-3)/(1))*(6)*((x--5)/(9))*((x-1)/(3))*((x--6)/(10))+((x-2)/(-7))*((x-0)/(-5))*((x-3)/(-8))*((x-4)/(-9))*(3)*((x-1)/(-6))*((x--6)/(1))+((x-2)/(-1))*((x-0)/(1))*((x-3)/(-2))*((x-4)/(-3))*((x--5)/(6))*(5)*((x--6)/(7))+((x-2)/(-8))*((x-0)/(-6))*((x-3)/(-9))*((x-4)/(-10))*((x--5)/(-1))*((x-1)/(-7))*(2)
```

放到 [图形计算器 - GeoGebra](https://link.zhihu.com/?target=https%3A//www.geogebra.org/graphing) 看看。

![img](https://pic2.zhimg.com/80/v2-6bb9304778112ad56eec6a21f9bad311_hd.jpg)看文章最上面的图片会比较清晰

完美地穿过所有点。

___

注意以 x/y 为主项时，你不能选取两个在 x/y 座标上相同的点。

例如：(0, 3), (0, 5) （以 x 为主项）

(7, 0), (9, 0) （以 y 为主项）

我们不能生成一个直线的函数。

## ▌代码：

代码中学写的，可读性很低，有空重构。

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

// 可怕。写得很差。

## ▌可能有兴趣的文章 ？

[【Just For Fun】n 階行列式計算 宏 生成器，四阶行列式的最优展开](https://zhuanlan.zhihu.com/p/77057988)

![img](https://pic2.zhimg.com/80/v2-686d2a84bffe0ccd300a38b15800ec65_hd.jpg)

[【Just For Fun】n 階行列式計算 宏 生成器（重构）](https://zhuanlan.zhihu.com/p/77388741)

___

**【Just For Fun】俺 是 目 录 ！**
