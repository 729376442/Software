[Variables]
GW=(#Scale#*#W#)
GH=(#Scale#*#H#)

Shuffle=1
Control=1
Repeat=0
Heart=1
Prog=1

HeartHover=0

[String:S]
FontFace=#FontFace#
FontSize=(10*#scale#)
AntiAlias=1
FontColor=#FontColor#
; ---------------------------------------------------------------------------- ;
;                                    Content                                   ;
; ---------------------------------------------------------------------------- ;

[B]
Meter=Shape
Shape=Rectangle 0,0,#GW#,#GH#,#R# | StrokeWidth #Stroke# | Fill Color #PrimaryColor#,#PrimaryOpacity# | Stroke Color #SecondaryColor#,#SecondaryOpacity#
Group=Music
[C]
Meter=Shape
X=r
Y=r
Shape=Rectangle 0,0,#GW#,#GH#,#R# | StrokeWidth 0
Group=Music 


[ImageFade]
Meter=Image
W=(#GW#)
H=(#GH#)
PreserveAspectRatio=2
MaskImageName=#@#Images\FadeMask.png
ImageName=[#PlayerType#Cover]
UpdateDivider=1
DynamicVariables=1
Group=Music | MediaImage
Container=C

[MusicIcon]
Meter=String
MeterStyle=String:S
X=(#P#)
Y=(#P#)
Text=[\xe3a1]
FontFace=Material Icons Round
FontSize=(12*#Scale#)
Group=Music
Hidden=#HidePlayerInfo#
Container=C

[Name]
Meter=String
MeterStyle=String:S
X=(#P#*3)
Y=r
W=(#GW#-(80*#Scale#)-3*#P#)
ClipString=1
Text=[#PlayerType#Player]
DynamicVariables=1
FontSize=(9*#Scale#)
Group=Music
Hidden=#HidePlayerInfo#
Container=C

[Track]
Meter=String
MeterStyle=String:S
X=(#P#)
Y=(#P#+#P#*2*(1-#HidePlayerInfo#))
W=(#GW#-(80*#Scale#)-3*#P#)
ClipString=1
Text=[#PlayerType#Track]
DynamicVariables=1
FontSize=(12*#Scale#)
FontWeight=650
Group=Music
Container=C

[Artist]
Meter=String
MeterStyle=String:S
X=r
Y=(5*#Scale#)R
W=(#GW#-(80*#Scale#)-3*#P#)
ClipString=1
Text=[#PlayerType#Artist]
DynamicVariables=1
Group=Music
Container=C

[ProgBar]
Meter=Shape
X=#P#
Y=(110*#scale#)
Shape=Line 0,0,(#GW#-#P#*2),0 | StrokeWidth (3*#scale#) | Fill Color 0,0,0,1 | Stroke Color #FontColor2# | StrokeStartCap Round | StrokeEndCap Round
Shape2=Line 0,0,((#GW#-#P#*2)*(Clamp([#PlayerType#Progress],0,100))/100),0 | StrokeWidth (3*#scale#) | Fill Color 0,0,0,1 | Stroke Color #AccentColor# | StrokeStartCap Round | StrokeEndCap Round
Shape3=Ellipse ((#GW#-#P#*2)*(Clamp([#PlayerType#Progress],0,100))/100),0,(#DotSize#/4),(#DotSize#/4) | strokeWidth 0 | Fill Color #AccentColor# | Scale #Scale#,#Scale#
Shape4=Line 0,0,(#GW#-#P#*2),0 | StrokeWidth (18*#scale#) | Fill Color 0,0,0,1 | Stroke Color 255,255,255,0 | StrokeStartCap Round | StrokeEndCap Round
LeftMouseUpAction=[!SetOption PosCalc Formula "($MouseX$/(#GW#-#P#*2)*100)"][!UpdateMeasure PosCalc]
DynamicVariables=1
UpdateDivider=1
Group=Music
Container=C
[PosCalc]
Measure=calc
OnUpdateAction=[!CommandMeasure state#NowPlayingMedia# "SetPosition [PosCalc]"][!UpdateMeasure #PlayerType#Progress]
Disabled=1
DynamicVariables=1
UpdateDivider=-1
Group=NUOL
[Current]
Meter=String
MeterStyle=String:S
X=r
Y=R
FontColor=#FontColor2#
DynamicVariables=1
UpdateDivider=1
FontSize=(9*#scale#)
MeasureName=#PlayerType#CurrentPosition
Group=Music
Container=C
[Length]
Meter=String
MeterStyle=String:S
X=(#GW#-#P#*2)r
Y=r
FontColor=#FontColor2#
StringAlign=Right
DynamicVariables=1
FontSize=(9*#scale#)
MeasureName=#PlayerType#Length
Group=Music
Container=C

[HeartCalc]
Measure=Calc
Formula= wnpHeart = 0 ? (#HeartHover# = 0 ? -1 : -2) : -3
Substitute="-1":"#FontColor2#","-2":"#FontColor#","-3":"#AccentColor#"
OnChangeAction=[!SetOption Heart ImageTint [HeartCalc]][!UpdateMeter Heart][!Redraw]
UpdateDivider=1
DynamicVariables=1
Group=Music

[Heart]
Meter=Image
X=(#GW#/2-(#IconSize#*5*#scale#+#IconPadding#*2*4+4*#Scale#)/2)
Y=(-15*#scale#)R
X=(#IconPadding#*2)R
Y=r
W=(#IconSize#*#scale#)
H=(#IconSize#*#scale#)
Grayscale=1
ImageTint=[HeartCalc]
UpdateDivider=1
DynamicVariables=1
Group=Music
Container=C
[FullHeart]
ImageName=#@#Icons\HeartFull.png
LeftMouseUpAction=[!UpdateMeasure HeartCalc][!SetOption Heart ImageTint #FontColor#][!SetOption #CURRENTSECTION# MeterStyle "EmptyHeart"][!UpdateMeter #CURRENTSECTION#][!Redraw][!CommandMeasure state#NowPlayingMedia# "ToggleThumbsDown"]
[EmptyHeart]
ImageName=#@#Icons\Heart.png
MouseOverAction=[!SetVariable HeartHover "1"][!WriteKeyValue Variables HeartHover "1"][!UpdateMeasure HeartCalc][!SetOption Heart ImageTint #FontColor#][!UpdateMeter #CURRENTSECTION#][!Redraw]
MouseLeaveAction=[!SetVariable HeartHover "0"][!WriteKeyValue Variables HeartHover "0"][!UpdateMeasure HeartCalc][!SetOption Heart ImageTint #FontColor2#][!UpdateMeter #CURRENTSECTION#][!Redraw]
LeftMouseUpAction=[!SetVariable HeartHover "0"][!WriteKeyValue Variables HeartHover "0"][!UpdateMeasure HeartCalc][!SetOption Heart ImageTint #AccentColor#][!SetOption #CURRENTSECTION# MeterStyle "Fullheart"][!UpdateMeter #CURRENTSECTION#][!Redraw][!CommandMeasure state#NowPlayingMedia# "ToggleThumbsUp"]

[Prev]
Meter=Image
ImageName=#@#Icons\Previous.png
ImageTint=#FontColor2#
LeftMouseUpAction=[!CommandMeasure state#NowPlayingMedia# "Previous"]
MouseOverAction=[!SetOption #CURRENTSECTION# ImageTint #FontColor#][!UpdateMeter #CURRENTSECTION#][!Redraw]
MouseLeaveAction=[!SetOption #CURRENTSECTION# ImageTint #FontColor2#][!UpdateMeter #CURRENTSECTION#][!Redraw]
X=(#IconPadding#*2)R
Y=r
W=(#IconSize#*#scale#)
H=(#IconSize#*#scale#)
Grayscale=1
DynamicVariables=1
Group=Music
Container=C

[PlayPause]
Meter=Image
X=(#IconPadding#*2 + 2 * #Scale#)R
Y=r
W=(#IconSize#*#scale#)
H=(#IconSize#*#scale#)
Grayscale=1
ImageTint=#FontColor2#
DynamicVariables=1
Group=Music
Container=C
[Play]
ImageName=#@#Icons\Play.png
MouseOverAction=[!SetOption #CURRENTSECTION# ImageTint #FontColor#][!UpdateMeter #CURRENTSECTION#][!Redraw]
MouseLeaveAction=[!SetOption #CURRENTSECTION# ImageTint #FontColor2#][!UpdateMeter #CURRENTSECTION#][!Redraw]
LeftMouseUpAction=[!SetOption PlayPause MeterStyle Pause][!UpdateMeter PlayPause][!Redraw][!CommandMeasure State#NowPlayingMedia# "PlayPause"]
[Pause]
ImageName=#@#Icons\Pause.png
MouseOverAction=[!SetOption #CURRENTSECTION# ImageTint #FontColor#][!UpdateMeter #CURRENTSECTION#][!Redraw]
MouseLeaveAction=[!SetOption #CURRENTSECTION# ImageTint #FontColor2#][!UpdateMeter #CURRENTSECTION#][!Redraw]
LeftMouseUpAction=[!SetOption PlayPause MeterStyle Play][!UpdateMeter PlayPause][!Redraw][!CommandMeasure State#NowPlayingMedia# "PlayPause"]

[Next]
Meter=Image
ImageName=#@#Icons\Next.png
ImageTint=#FontColor2#
LeftMouseUpAction=[!CommandMeasure state#NowPlayingMedia# "Next"]
MouseOverAction=[!SetOption #CURRENTSECTION# ImageTint #FontColor#][!UpdateMeter #CURRENTSECTION#][!Redraw]
MouseLeaveAction=[!SetOption #CURRENTSECTION# ImageTint #FontColor2#][!UpdateMeter #CURRENTSECTION#][!Redraw]
X=(#IconPadding#*2 + 2 * #Scale#)R
Y=r
W=(#IconSize#*#scale#)
H=(#IconSize#*#scale#)
Grayscale=1
DynamicVariables=1
Group=Music
Container=C

[Shuffle]
Meter=Image
ImageName=#@#Icons\Shuffle.png
X=(#IconPadding#*2)R
Y=r
W=(#IconSize#*#scale#)
H=(#IconSize#*#scale#)
Grayscale=1
DynamicVariables=1
Group=Music
Container=C
[Shuffle0]
ImageTint=#FontColor2#
MouseOverAction=[!SetOption #CURRENTSECTION# ImageTint #FontColor#][!UpdateMeter #CURRENTSECTION#][!Redraw]
MouseLeaveAction=[!SetOption #CURRENTSECTION# ImageTint #FontColor2#][!UpdateMeter #CURRENTSECTION#][!Redraw]
LeftMouseUpAction=[!SetOption #CURRENTSECTION# ImageTint #AccentColor#][!UpdateMeter #CURRENTSECTION#][!SetOption Shuffle MeterStyle "Shuffle1"][!UpdateMeter Shuffle][!Redraw][!CommandMeasure state#NowPlayingMedia# "Shuffle"]
[Shuffle1]
ImageTint=#AccentColor#
LeftMouseUpAction=[!SetOption #CURRENTSECTION# ImageTint #FontColor#][!UpdateMeter #CURRENTSECTION#][!SetOption Shuffle MeterStyle "Shuffle0"][!UpdateMeter Shuffle][!Redraw][!CommandMeasure state#NowPlayingMedia# "Shuffle"]


[Image]
Meter=Image
X=(#GW#-(80*#Scale#)-#P#)
Y=#P#
W=(80*#Scale#)
H=(80*#Scale#)
PreserveAspectRatio=2
MaskImageName=#@#Images\Mask.png
ImageName=[#PlayerType#Cover]
UpdateDivider=1
DynamicVariables=1
Group=Music | MediaImage
Container=C