
//===================================================
//作    者：徐艺航
//创建时间：2020-11-03 16:22:29
//备    注：此代码为工具生成 请勿手工修改
//===================================================
using System.Collections;
using System.Collections.Generic;
using System;

/// <summary>
/// Product数据管理
/// </summary>
public partial class ProductDBModel : AbstractDBModel<ProductDBModel, ProductEntity>
{
    /// <summary>
    /// 文件名称
    /// </summary>
    protected override string FileName { get { return "Product.data"; } }

    /// <summary>
    /// 创建实体
    /// </summary>
    /// <param name="parse"></param>
    /// <returns></returns>
    protected override ProductEntity MakeEntity(GameDataTableParser parse)
    {
        ProductEntity entity = new ProductEntity();
        entity.Id = parse.GetFieldValue("Id").ToInt();
        entity.Name = parse.GetFieldValue("Name");
        entity.Price = parse.GetFieldValue("Price").ToFloat();
        entity.PicName = parse.GetFieldValue("PicName");
        entity.Desc = parse.GetFieldValue("Desc");
        return entity;
    }
}
