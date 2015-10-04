## XML Basics
### _Homework_

1.  What does the XML language represent? What is it used for? 
	- XML (eXtensible Markup Language)
		+ Universal language (notation) for describing structured data using text with tags
		+ The data is stored together with the meta-data about it
		+ Used to describe other languages (formats) for data representation
	- XML looks like HTML
		 Text based language, uses tags and attributes
1.  Create XML document `students.xml`, which contains structured description of students. 
    - For each student you should enter information for his name, sex, birth date, phone, email, course, specialty, faculty number and a list of taken exams (exam name, tutor, score).
    
1.  What do namespaces represent in an XML document? What are they used for?
    - In XML, element names are defined by the developer. This often results in a conflict when trying to mix XML documents from different XML applications. A user or an XML application will not know how to handle these differences. Name conflicts in XML can easily be avoided using a name prefix. When using prefixes in XML, a namespace for the prefix must be defined. The namespace can be defined by an xmlns attribute in the start tag of an element. The namespace declaration has the following syntax. xmlns:prefix="URI".
    - Namespaces in XML documents allow using different tags with the same name
1.  Explore http://en.wikipedia.org/wiki/Uniform_Resource_Identifier to learn more about URI, URN and URL definitions.
1.  Add default namespace for students "`urn:students`".
1.  Create XSD Schema for `students.xml` document.
  * Add new elements in the schema: information for enrollment (date and exam score) and teacher's endorsements.
1.  Write an XSL stylesheet to visualize the students as HTML.
  * Test it in your favourite browser.
