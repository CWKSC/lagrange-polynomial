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
