from pyspark.sql import SparkSession
from pyspark.sql.functions import col

#	 ��� ��� ������ �������� (df_products) ����� �������������� ����� ��������� (df_categories), ����� ��������� ���� ����� 
# ��������������� ����� ���������, �� ����� ���� ������� ����� ������ �� ������. �������������, ������ ���� ��� ���� ��������������
# ��������� ����������� �� (df_product_category).
#	 �����, ����� �������� ������ ���� ��� ������� - ���������, ���� ���� � �������� ��� ���������, ����� ����������� ��������� �������:


def get_products_with_categories(df_products, df_categories, df_product_category):
    result = df_products.join(df_product_category, df_products.Id == df_product_category.ProductId, how='left').\
    join(df_categories, df_product_category.CategoryId == df_categories.Id, how='left').\
    select((df_products.Name).alias('ProductName'), (df_categories.Name).alias('CategoryName'))
    return result

if(__name__ == "__main__"):
    spark = SparkSession.builder.appName('spark_session').getOrCreate()

    products =  spark.createDataFrame(
        [(1, 'Product1'), 
        (2, 'Product2'), 
        (3, 'Product3'),
        (4, 'Product4')],
        ['Id', 'Name'] 
    )

    categories = spark.createDataFrame(
        [(1, 'Category1'), 
        (2, 'Category2'), 
        (3, 'Category3')],
        ['Id', 'Name']
    )

    product_category = spark.createDataFrame(
        [(1, 1), 
        (2, 3), ],
        ['ProductId', 'CategoryId']
    )

    get_products_with_categories(products, categories, product_category).show()