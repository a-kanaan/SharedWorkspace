# -*- coding: utf-8 -*-
"""knn.ipynb

Automatically generated by Colaboratory.

Original file is located at
    https://colab.research.google.com/gist/a-kanaan/e1d5d3fe430fca462d6fca0d4b172024/knn.ipynb

# شكل البيانات

|البيض|الماء| الطحين| النتيجة|
|------|------|------|------|
|3  |1  |3  | جيد|
|4  |1  |4  | جيد |
|3  |2  |3  | سيء |
|3  |2  |4  | سيء |

# تمثيل البيانات في بايثون
"""

import pandas as pd

data = pd.DataFrame([[3, 1, 3], [4, 1, 4], [3, 2, 3], [3, 2, 4]], columns= ['البيض', 'الماء', 'الطحين'])
data['النتجية'] = [0, 0, 1, 1]
data

# نعرف المتحول x أو س
x = data.iloc[:, :-1]
x

y = data.iloc[:, -1]
y

"""# تطبيق خوارزمية kNN يدويا"""

x0 = pd.array([4, 2, 4])
a = (x - x0)**2
data['المسافة'] = a.sum(axis=1)
data

"""# تطبيق خوارزمية kNN باستخدام مكتبة sklearn"""

from sklearn.neighbors import KNeighborsClassifier
k = 3

knn = KNeighborsClassifier(n_neighbors=k).fit(x, y)

knn.predict([x0])