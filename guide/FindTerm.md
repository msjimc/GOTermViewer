## [Back to guide](/guide/readme.md)

# Find terms

As mentioned earlier, GO terms are order in a are ordered in a hierarchical manner formally described has a cyclic graph. This means that moving from the root term it may be possible to reach a GO term via a number of different route. While this arrangement is easy to navigate moving from one term to one of its child terms, but because a term may have multiple parents it can be very difficult to draw without becoming confusing (see image on the  Gene Ontology Consortium web site http://geneontology.org/docs/ontology-documentation/). This problem becomes even more evident when enrichment data is included. To remove this issue, the links between GO terms are represented as a series of paths from the root term to individual terms. This means that a term will occur multiple times in the tree view. This can make it difficult to find individual terms and as importantly, a term in the desired context. Consequently, GOTermViewer has two GO term search functions, the first allows you to find a path to specific term that also includes certain intermediate terms, while the second method allows to enter several terms and then identifies the nearest parent term that includes all the selected terms. 

## Finding a specific GO Term

 To search for a specific term right clicking anywhere on the tree view (Figure 1) and them clicking on the 'Find GO term' menu item.

![figure 1](images/figF1.jpg?raw=true "Figure 1")

Figure 1

Clicking on the 'Find GO term' menu item will cause the 'Find GO Term' window to open (Figure 2). This form consists of a number of text boxes and a dropdown list, to start the search, start to type the name of the term you which to find in the top text box.   

![figure 2](images/figf2.jpg?raw=true "Figure 2")

Figure 2

Once 4 or more characters have been typed, a list of all the GO terms containing that text will appear in the drop-down list below it (Figure 3). Look through this list to find the desired term and select it.  
If no data was linked to the term __(NO DATA)__ will be appended to the term in the drop-down list. You can still use this term, but the relevant term will not be visible in the tree view. If you need to see any data linked to this term, you will need to reimport the data using a less significant cutoff value.

![figure 3](images/figf3.jpg?raw=true "Figure 3")

Figure 3

The lower text area will contain all the paths that link the selected term to the root term. The paths are drawn with the selected term to the right and its parent, grandparent, etc to its right. Depending on the term there may be serval hundred paths (Figure 4).

![figure 4](images/figf4.jpg?raw=true "Figure 4")

Figure 4

It is possible to scroll through the list to find a path that is best suited to your needs, for instance if you are interested in RNA degradation you may be more interested in a path that includes 'Macromolecule metabolic process' than 'Nucleobase-containing compound catabolic process'. You can filter these by entering text in the text area below the dropdown list. Only terms that include the text will be retained (figure 5)

![figure 5](images/figf5b.jpg?raw=true "Figure 5")

Figure 5

Rather than just selecting for terms with the desired text, it is possible to exclude terms that contain the text by adding the 'NOT ' prefix (Figure 6)

![figure 6](images/figf5a.jpg?raw=true "Figure 6")

Figure 6

It is possible to combine multiple search terms by creating a list with the ';' character separating each term (Figure 7)

![figure 7](images/figf5c.jpg?raw=true "Figure 7")

Figure 7

Once you have identified your desired path(s), check the box to the left of the text (figure 8) and press the 'OK' button to close the window.

![figure 8](images/figf6.jpg?raw=true "Figure 8")

Figure 8

Once the search form closes, the terms in the selected path(s) will be selected in the tree view (Figure 9) allowing you to then select related terms such as 'mRNA catabolic process', 'ncRNA-catabolic process' and 'Pre-mRNA catabolic process' (figure 10)

![figure 9](images/figf7.jpg?raw=true "Figure 9")

Figure 9

![figure 10](images/figf8.jpg?raw=true "Figure 10")

Figure 10

As stated earlier, a term may appear multiple times with different flanking terms. In Figure 11, RNA catabolic process has been selected as before, but this time a path containing 'Nucleobase-containing compound catabolic process' was chosen (Figure 11).  

![figure 11](images/figf9.jpg?raw=true "Figure 11")

Figure 11

When accepted, this caused a significantly different path to be displayed that passed through 'Cellular metabolic process' (Figure 12) and not 'Metabolic process'. This located the term next to terms such as 'Nucleoside phosphate catabolic process' and 'DNA catabolic process' compared to 'Protein catabolic process' and 'Receptor catabolic process'.

![figure 12](images/figf10.jpg?raw=true "Figure 12")

Figure 12

When the results of both searches are shown in the same display it can be seen that each time the 'RNA catabolic process' has the same child terms, but different parent terms.

![figure 13](images/figf11.jpg?raw=true "Figure 13")

Figure 13

## Find closest common term to a set of GO terms.

If you wish to visualise enrichment data for terms that are not obviously linked, it is possible to search for the nearest common term to a number of specific terms, to do this right click on the tree area and select the 'Find common path' item (Figure 14)

![figure 14](images/figf12.jpg?raw=true "Figure 14")

Figure 14

Once you have typed 4 or more characters in the top left text area, GO terms containing the text appear in the drop-down list to the right of the text area. To add a specific term, select it from the drop-down list and press 'Add' (Figure 15). If no data was imported of a term that was statistically significant the text _(NO DATA)_ is appended to the term. While it is possible to proceed, this term will not appear in the tree view (unless you have deselected the 'Only show terms with data in them or their children' option). If you wish to view any data linked to this term, re-importing the enrichment data setting the cut off to a less stringent value such as 1 may reveal statistically insignificant data.

![figure 15](images/figf15.jpg?raw=true "Figure 15")

Figure 15

As terms are selected, they appear in the lower drop-down list box (Figure 16). To remove a selected term, select it in this list and press the 'Remove' button.

![figure 16](images/figf16.jpg?raw=true "Figure 16")

Figure 16

Once two or more terms have been added, press the 'Find' button to identify a term that is closely linked to all the selected terms. All possible paths to this term will be displayed in the lower text area. To view this path in the tree view check one (or more) of the paths and accept by pressing the 'Accept' button (Figure 17).

![figure 17](images/figf17.jpg?raw=true "Figure 17")

Figure 17

The form will close and the relevant terms will be checked in the tree view. From there, examine the terms in the tree view and select the relevant terms.

![figure 18](images/figf18.jpg?raw=true "Figure 18")

Figure 18
