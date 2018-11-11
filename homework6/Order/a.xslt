<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:output method="xml" indent="yes"/>

  <xsl:template match="@* | node()">
    <xsl:copy>
      <xsl:apply-templates select="@* | node()"/>
    </xsl:copy>
  </xsl:template>

  <xsl:template match="ArrayOfOrder">
    <html>
      <head>ArrayOfOrder</head>
      <body>
        <table border="1">
          <tr  bgcolor="#9acd32">
            <th>订单号</th>
            <th>客户名</th>
            <th>订单金额</th>
          </tr>

          <xsl:for-each select="Order">
            <tr>
              <td>
                <xsl:value-of select="Id"/>
              </td>
              <td>
                <xsl:value-of select="Customer"/>
              </td>
              <td>
                <xsl:value-of select="OrderMoney"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
        <xsl:for-each select="Order">
          <h>
            Order <xsl:value-of select="Id"/>
          </h>
          <table border="1">
            <tr  bgcolor="#9acd32">
              <th>商品名</th>
              <th>商品价格</th>
              <th>购买数量</th>
              <th>总金额</th>
            </tr>
            <xsl:for-each select="list">
              <xsl:for-each select="OrderDetail">

                <tr>
                  <xsl:for-each select="Goods">
                    <td>
                      <xsl:value-of select="Name"/>
                    </td>
                    <td>
                      <xsl:value-of select="Price"/>
                    </td>
                  </xsl:for-each>
                  <td>
                    <xsl:value-of select="Quantity"/>
                  </td>
                  <td>
                    <xsl:value-of select="Money"/>
                  </td>
                </tr>
              </xsl:for-each>
            </xsl:for-each>
          </table>
        </xsl:for-each>

      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
