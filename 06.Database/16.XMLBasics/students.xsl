<?xml version="1.0"?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:st="urn:students">
  <xsl:template match="/">
    <html>
      <body>
        <h1>My Library</h1>
        <table bgcolor="#E0E0E0" cellspacing="1">
          <tr bgcolor="#EEEEEE">
            <td>
              <b>Name</b>
            </td>
            <td>
              <b>Sex</b>
            </td>
            <td>
              <b>Birth Date</b>
            </td>
            <td>
              <b>Phone</b>
            </td>
          </tr>
          <xsl:for-each select="st:students/st:student">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="st:name"/>
              </td>
              <td>
                <xsl:value-of select="st:sex"/>
              </td>
              <td>
                <xsl:value-of select="st:birth_date"/>
              </td>
              <td>
                <xsl:value-of select="st:phone"/>
              </td>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>