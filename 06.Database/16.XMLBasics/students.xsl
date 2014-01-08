<?xml version="1.0"?>
<xsl:stylesheet version="1.0" 
                xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                xmlns:st="urn:students">
  <xsl:template match="/">
    <html>
      <body>
        <h1>Students System</h1>
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
			<td>
              <b>E-mail</b>
            </td>
			<td>
              <b>Cource</b>
            </td>
			<td>
              <b>Specialty</b>
            </td>
			<td>
              <b>Faculty Number</b>
            </td>			
			<td>
              <b>Exam Name</b>
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
			  <td>
                <xsl:value-of select="st:email"/>
              </td>
              <td>
                <xsl:value-of select="st:course"/>
              </td>
              <td>
                <xsl:value-of select="st:specialty"/>
              </td>
              <td>
                <xsl:value-of select="st:faculty_number"/>
              </td>
		  <xsl:for-each select="st:students/st:student/st:taken_exams">
            <tr bgcolor="white">
              <td>
                <xsl:value-of select="st:exam_name"/>
              </td>
			</tr>
		  </xsl:for-each>
            </tr>
          </xsl:for-each>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>