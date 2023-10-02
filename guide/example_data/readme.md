# GOTermViewer

## Example data

The data used in the guide was obtained from the NCBi GEO web site as the GEO project: 
[GSE237377](https://www.ncbi.nlm.nih.gov/geo/query/acc.cgi?acc=GSE237377)
who's analysis was published in _'Frontiers in Endocrinology'_

Web link:	https://www.frontiersin.org/articles/10.3389/fendo.2023.1226808

Series: GSE186116		

Status:	Public on Aug 16, 2023

Title:	Elucidating the effect of a new indoline derivative (AN1284) against Non-alcoholic steatohepatitis

Organism:	Mus musculus

Experiment type:	Expression profiling by high throughput sequencing

Summary:	

The aim of the current study was to check whether chronic treatment with AN1284 could reverse steatosis and fibrosis in a mouse model of NASH. We used a mouse model of dietary induced NASH that was given for 4 month. Treatment with saline or AN1284 was given via implanted minipumps for 2 month. Treatment was started after 2 month feeding. Our results revealed that AN1284 significantly attenuated liver damage, as indicated by a reduced liver/body ratio, decreased ALT serum levels, a significant reduction in liver fat content and hepatic fibrosis. To investigate the underlying mechanism, we performed RNA sequencing on mice fed with normal diet (ND) or high fat diet (HFD; Envigo-Teklad TD.150235).

Overall design:	

Mice were fed with normal diet (ND) or high fat diet (HFD; Envigo-Teklad TD.150235), and given either saline or AN1284 in two doses, 1mg and 5mg per kg per day. At least 3 replicates were performed for each condition.

Series GSE186116		Query DataSets for GSE186116
Status	Public on Aug 16, 2023
Title	Elucidating the effect of a new indoline derivative (AN1284) against Non-alcoholic steatohepatitis
Organism	Mus musculus
Experiment type	Expression profiling by high throughput sequencing
Summary	The aim of the current study was to check whether chronic treatment with AN1284 could reverse steatosis and fibrosis in a mouse model of NASH. We used a mouse model of dietary induced NASH that was given for 4 month. Treatment with saline or AN1284 was given via implanted minipumps for 2 month. Treatment was started after 2 month feeding. Our results revealed that AN1284 significantly attenuated liver damage, as indicated by a reduced liver/body ratio, decreased ALT serum levels, a significant reduction in liver fat content and hepatic fibrosis. To investigate the underlying mechanism, we performed RNA sequencing on mice fed with normal diet (ND) or high fat diet (HFD; Envigo-Teklad TD.150235).
 	
Overall design	Mice were fed with normal diet (ND) or high fat diet (HFD; Envigo-Teklad TD.150235), and given either saline or AN1284 in two doses, 1mg and 5mg per kg per day. At least 3 replicates were performed for each condition.
  
Contributor(s):	

Yehezkel AS, Weinstock M, Abramovitch R

## Very brief discription of the analysis
The data was downloaded from the SRA site and converted to individual fastq.gz files. These were trimmed for adaptor sequences and low quality base calls using cutadapt before been aligned to the mouse genome using STAR. Reads mapping to genes/transcripts in the RefSeq dataset where counted using the R package subRead. The transcript count data was then processed using DeSeq2 to identify the the differentially expressed genes, which were then processed by GOStats with reference to all the genes expressed in the sample's transcriptome. The analysis was performed for both over and under-enriched terms in the 'Biological process' set, with the files combined together as described in the Guide readme.md file.
