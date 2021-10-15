using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using Crestron;
using Crestron.Logos.SplusLibrary;
using Crestron.Logos.SplusObjects;
using Crestron.SimplSharp;

namespace CrestronModule_MARANTZ_AV7702_PROCESSOR_V1_0
{
    public class CrestronModuleClass_MARANTZ_AV7702_PROCESSOR_V1_0 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        Crestron.Logos.SplusObjects.BufferInput FROM_DEVICE;
        Crestron.Logos.SplusObjects.DigitalInput AM_SELECTED;
        Crestron.Logos.SplusObjects.DigitalInput FM_SELECTED;
        Crestron.Logos.SplusObjects.DigitalInput CLEAR;
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> HD_TUNER_KP;
        Crestron.Logos.SplusObjects.BufferInput RESPONSE_NSE;
        InOutArray<Crestron.Logos.SplusObjects.DigitalOutput> HIGHLIGHT_LINE;
        Crestron.Logos.SplusObjects.StringOutput MAIN_VOLUME_TEXT;
        Crestron.Logos.SplusObjects.AnalogOutput MAIN_VOLUME_GAUGE;
        Crestron.Logos.SplusObjects.StringOutput ZONE_2_VOLUME_TEXT;
        Crestron.Logos.SplusObjects.AnalogOutput ZONE_2_VOLUME_GAUGE;
        Crestron.Logos.SplusObjects.StringOutput ZONE_3_VOLUME_TEXT;
        Crestron.Logos.SplusObjects.AnalogOutput ZONE_3_VOLUME_GAUGE;
        Crestron.Logos.SplusObjects.StringOutput FRONT_LEFT_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput FRONT_RIGHT_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput CENTER_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput SUBWOOFER_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput SUBWOOFER_2_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput SURROUND_LEFT_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput SURROUND_RIGHT_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput SURROUND_BACK_LEFT_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput SURROUND_BACK_RIGHT_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput SURROUND_BACK_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput FRONT_HEIGHT_LEFT_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput FRONT_HEIGHT_RIGHT_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput FRONT_WIDE_LEFT_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput FRONT_WIDE_RIGHT_LEVEL_TEXT;
        Crestron.Logos.SplusObjects.StringOutput TUNER_FREQUENCY;
        Crestron.Logos.SplusObjects.StringOutput TO_DEVICE;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> LINE_OUT;
        InOutArray<Crestron.Logos.SplusObjects.StringOutput> NET_AUDIO_PRESET_NAME_TEXT;
        ushort IPROCESSFROMDEVICE = 0;
        ushort IVALUE = 0;
        ushort IMVMAX = 0;
        ushort ISTATIONVALUE = 0;
        ushort ISEMAPHORE = 0;
        CrestronString SHDTUNERNUMBER;
        CrestronString SHDTUNERCOMMAND;
        CrestronString SFROMDEVICE;
        CrestronString SRESPONSE;
        CrestronString SDUMP;
        CrestronString SSELECTEDCHAR;
        ushort ISTRINGNUMBER = 0;
        private CrestronString CALCULATE_LEVEL (  SplusExecutionContext __context__, ushort IVALUE ) 
            { 
            CrestronString SLEVELTEXT;
            SLEVELTEXT  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 8, this );
            
            
            __context__.SourceCodeLine = 175;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVALUE >= 500 ))  ) ) 
                {
                __context__.SourceCodeLine = 176;
                MakeString ( SLEVELTEXT , "{0:d}.{1:d} dB", (short)((IVALUE - 500) / 10), (short)Mod( (IVALUE - 500) , 10 )) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 178;
                MakeString ( SLEVELTEXT , "-{0:d}.{1:d} dB", (short)((500 - IVALUE) / 10), (short)Mod( (500 - IVALUE) , 10 )) ; 
                }
            
            __context__.SourceCodeLine = 179;
            return ( SLEVELTEXT ) ; 
            
            }
            
        object HD_TUNER_KP_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                ushort A = 0;
                
                
                __context__.SourceCodeLine = 192;
                
                    {
                    int __SPLS_TMPVAR__SWTCH_1__ = ((int)Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ));
                    
                        { 
                        if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 1) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 196;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SHDTUNERNUMBER ) < 4 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 197;
                                MakeString ( SHDTUNERNUMBER , "{0}1", SHDTUNERNUMBER ) ; 
                                }
                            
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 2) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 201;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SHDTUNERNUMBER ) < 4 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 202;
                                MakeString ( SHDTUNERNUMBER , "{0}2", SHDTUNERNUMBER ) ; 
                                }
                            
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 3) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 206;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SHDTUNERNUMBER ) < 4 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 207;
                                MakeString ( SHDTUNERNUMBER , "{0}3", SHDTUNERNUMBER ) ; 
                                }
                            
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 4) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 211;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SHDTUNERNUMBER ) < 4 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 212;
                                MakeString ( SHDTUNERNUMBER , "{0}4", SHDTUNERNUMBER ) ; 
                                }
                            
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 5) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 216;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SHDTUNERNUMBER ) < 4 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 217;
                                MakeString ( SHDTUNERNUMBER , "{0}5", SHDTUNERNUMBER ) ; 
                                }
                            
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 6) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 221;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SHDTUNERNUMBER ) < 4 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 222;
                                MakeString ( SHDTUNERNUMBER , "{0}6", SHDTUNERNUMBER ) ; 
                                }
                            
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 7) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 226;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SHDTUNERNUMBER ) < 4 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 227;
                                MakeString ( SHDTUNERNUMBER , "{0}7", SHDTUNERNUMBER ) ; 
                                }
                            
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 8) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 231;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SHDTUNERNUMBER ) < 4 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 232;
                                MakeString ( SHDTUNERNUMBER , "{0}8", SHDTUNERNUMBER ) ; 
                                }
                            
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 9) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 236;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SHDTUNERNUMBER ) < 4 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 237;
                                MakeString ( SHDTUNERNUMBER , "{0}9", SHDTUNERNUMBER ) ; 
                                }
                            
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 10) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 241;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SHDTUNERNUMBER ) < 4 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 242;
                                MakeString ( SHDTUNERNUMBER , "{0}0", SHDTUNERNUMBER ) ; 
                                }
                            
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 11) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 246;
                            Functions.ClearBuffer ( SHDTUNERNUMBER ) ; 
                            } 
                        
                        else if  ( Functions.TestForTrue  (  ( __SPLS_TMPVAR__SWTCH_1__ == ( 12) ) ) ) 
                            { 
                            __context__.SourceCodeLine = 250;
                            if ( Functions.TestForTrue  ( ( AM_SELECTED  .Value)  ) ) 
                                { 
                                __context__.SourceCodeLine = 252;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SHDTUNERNUMBER ) == 3))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 253;
                                    MakeString ( TO_DEVICE , "TFHD0{0}00\u000D", SHDTUNERNUMBER ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 254;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SHDTUNERNUMBER ) == 4))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 255;
                                        MakeString ( TO_DEVICE , "TFHD{0}00\u000D", SHDTUNERNUMBER ) ; 
                                        }
                                    
                                    }
                                
                                } 
                            
                            __context__.SourceCodeLine = 257;
                            if ( Functions.TestForTrue  ( ( FM_SELECTED  .Value)  ) ) 
                                { 
                                __context__.SourceCodeLine = 259;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SHDTUNERNUMBER ) == 3))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 260;
                                    MakeString ( TO_DEVICE , "TFHD00{0}0\u000D", SHDTUNERNUMBER ) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 261;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SHDTUNERNUMBER ) == 4))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 262;
                                        MakeString ( TO_DEVICE , "TFHD0{0}0\u000D", SHDTUNERNUMBER ) ; 
                                        }
                                    
                                    }
                                
                                } 
                            
                            __context__.SourceCodeLine = 264;
                            Functions.ClearBuffer ( SHDTUNERNUMBER ) ; 
                            } 
                        
                        } 
                        
                    }
                    
                
                __context__.SourceCodeLine = 267;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SHDTUNERNUMBER ) > 0 ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 269;
                    if ( Functions.TestForTrue  ( ( AM_SELECTED  .Value)  ) ) 
                        {
                        __context__.SourceCodeLine = 270;
                        MakeString ( TUNER_FREQUENCY , "{0}*", SHDTUNERNUMBER ) ; 
                        }
                    
                    __context__.SourceCodeLine = 271;
                    if ( Functions.TestForTrue  ( ( FM_SELECTED  .Value)  ) ) 
                        {
                        __context__.SourceCodeLine = 272;
                        MakeString ( TUNER_FREQUENCY , "{0}.{1}*", Functions.Left ( SHDTUNERNUMBER ,  (int) ( (Functions.Length( SHDTUNERNUMBER ) - 1) ) ) , Functions.Right ( SHDTUNERNUMBER ,  (int) ( 1 ) ) ) ; 
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 275;
                    MakeString ( TUNER_FREQUENCY , "*") ; 
                    }
                
                
                
            }
            catch(Exception e) { ObjectCatchHandler(e); }
            finally { ObjectFinallyHandler( __SignalEventArg__ ); }
            return this;
            
        }
        
    object FROM_DEVICE_OnChange_1 ( Object __EventInfo__ )
    
        { 
        Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
        try
        {
            SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
            
            __context__.SourceCodeLine = 280;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IPROCESSFROMDEVICE == 0))  ) ) 
                { 
                __context__.SourceCodeLine = 282;
                IPROCESSFROMDEVICE = (ushort) ( 1 ) ; 
                __context__.SourceCodeLine = 283;
                while ( Functions.TestForTrue  ( ( 1)  ) ) 
                    { 
                    __context__.SourceCodeLine = 285;
                    SRESPONSE  .UpdateValue ( Functions.Gather ( "\u000D" , FROM_DEVICE )  ) ; 
                    __context__.SourceCodeLine = 287;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "MVMAX" , SRESPONSE ) == 1))  ) ) 
                        { 
                        __context__.SourceCodeLine = 289;
                        IMVMAX = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                        __context__.SourceCodeLine = 290;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 9))  ) ) 
                            {
                            __context__.SourceCodeLine = 291;
                            IMVMAX = (ushort) ( (IMVMAX * 10) ) ; 
                            }
                        
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 293;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "MV" , SRESPONSE ) == 1))  ) ) 
                            { 
                            __context__.SourceCodeLine = 295;
                            IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                            __context__.SourceCodeLine = 296;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 5))  ) ) 
                                {
                                __context__.SourceCodeLine = 297;
                                IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                }
                            
                            __context__.SourceCodeLine = 298;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVALUE >= 800 ))  ) ) 
                                {
                                __context__.SourceCodeLine = 299;
                                MakeString ( MAIN_VOLUME_TEXT , "{0:d}.{1:d}dB", (short)((IVALUE - 800) / 10), (short)Mod( (IVALUE - 800) , 10 )) ; 
                                }
                            
                            else 
                                {
                                __context__.SourceCodeLine = 300;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVALUE >= 5 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 301;
                                    MakeString ( MAIN_VOLUME_TEXT , "-{0:d}.{1:d}dB", (short)((800 - IVALUE) / 10), (short)Mod( (800 - IVALUE) , 10 )) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 303;
                                    MakeString ( MAIN_VOLUME_TEXT , "---.-dB") ; 
                                    }
                                
                                }
                            
                            __context__.SourceCodeLine = 304;
                            MAIN_VOLUME_GAUGE  .Value = (ushort) ( ((IVALUE * 65535) / IMVMAX) ) ; 
                            } 
                        
                        else 
                            {
                            __context__.SourceCodeLine = 306;
                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Find( "Z2" , SRESPONSE ) == 1) ) && Functions.TestForTrue ( Functions.BoolToInt ( Byte( SRESPONSE , (int)( 3 ) ) > 47 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Byte( SRESPONSE , (int)( 3 ) ) < 58 ) )) ))  ) ) 
                                { 
                                __context__.SourceCodeLine = 308;
                                IVALUE = (ushort) ( Functions.Atoi( Functions.Mid( SRESPONSE , (int)( 3 ) , (int)( 2 ) ) ) ) ; 
                                __context__.SourceCodeLine = 309;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVALUE >= 80 ))  ) ) 
                                    {
                                    __context__.SourceCodeLine = 310;
                                    MakeString ( ZONE_2_VOLUME_TEXT , "+{0:d}dB", (short)(IVALUE - 80)) ; 
                                    }
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 311;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVALUE >= 1 ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 312;
                                        MakeString ( ZONE_2_VOLUME_TEXT , "-{0:d}dB", (short)(80 - IVALUE)) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 314;
                                        MakeString ( ZONE_2_VOLUME_TEXT , "---dB") ; 
                                        }
                                    
                                    }
                                
                                __context__.SourceCodeLine = 315;
                                ZONE_2_VOLUME_GAUGE  .Value = (ushort) ( ((IVALUE * 65535) / 98) ) ; 
                                } 
                            
                            else 
                                {
                                __context__.SourceCodeLine = 317;
                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (Functions.Find( "Z3" , SRESPONSE ) == 1) ) && Functions.TestForTrue ( Functions.BoolToInt ( Byte( SRESPONSE , (int)( 3 ) ) > 47 ) )) ) ) && Functions.TestForTrue ( Functions.BoolToInt ( Byte( SRESPONSE , (int)( 3 ) ) < 58 ) )) ))  ) ) 
                                    { 
                                    __context__.SourceCodeLine = 319;
                                    IVALUE = (ushort) ( Functions.Atoi( Functions.Mid( SRESPONSE , (int)( 3 ) , (int)( 2 ) ) ) ) ; 
                                    __context__.SourceCodeLine = 320;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVALUE >= 80 ))  ) ) 
                                        {
                                        __context__.SourceCodeLine = 321;
                                        MakeString ( ZONE_3_VOLUME_TEXT , "+{0:d}dB", (short)(IVALUE - 80)) ; 
                                        }
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 322;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( IVALUE >= 1 ))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 323;
                                            MakeString ( ZONE_3_VOLUME_TEXT , "-{0:d}dB", (short)(80 - IVALUE)) ; 
                                            }
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 325;
                                            MakeString ( ZONE_3_VOLUME_TEXT , "---dB") ; 
                                            }
                                        
                                        }
                                    
                                    __context__.SourceCodeLine = 326;
                                    ZONE_3_VOLUME_GAUGE  .Value = (ushort) ( ((IVALUE * 65535) / 98) ) ; 
                                    } 
                                
                                else 
                                    {
                                    __context__.SourceCodeLine = 328;
                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVFL" , SRESPONSE ) == 1))  ) ) 
                                        { 
                                        __context__.SourceCodeLine = 330;
                                        IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                        __context__.SourceCodeLine = 331;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 8))  ) ) 
                                            {
                                            __context__.SourceCodeLine = 332;
                                            IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                            }
                                        
                                        __context__.SourceCodeLine = 333;
                                        FRONT_LEFT_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                        } 
                                    
                                    else 
                                        {
                                        __context__.SourceCodeLine = 335;
                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVFR" , SRESPONSE ) == 1))  ) ) 
                                            { 
                                            __context__.SourceCodeLine = 337;
                                            IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                            __context__.SourceCodeLine = 338;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 8))  ) ) 
                                                {
                                                __context__.SourceCodeLine = 339;
                                                IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                                }
                                            
                                            __context__.SourceCodeLine = 340;
                                            FRONT_RIGHT_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                            } 
                                        
                                        else 
                                            {
                                            __context__.SourceCodeLine = 342;
                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVC" , SRESPONSE ) == 1))  ) ) 
                                                { 
                                                __context__.SourceCodeLine = 344;
                                                IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                                __context__.SourceCodeLine = 345;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 7))  ) ) 
                                                    {
                                                    __context__.SourceCodeLine = 346;
                                                    IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                                    }
                                                
                                                __context__.SourceCodeLine = 347;
                                                CENTER_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                                } 
                                            
                                            else 
                                                {
                                                __context__.SourceCodeLine = 349;
                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVSW" , SRESPONSE ) == 1))  ) ) 
                                                    { 
                                                    __context__.SourceCodeLine = 351;
                                                    IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                                    __context__.SourceCodeLine = 352;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 8))  ) ) 
                                                        {
                                                        __context__.SourceCodeLine = 353;
                                                        IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                                        }
                                                    
                                                    __context__.SourceCodeLine = 354;
                                                    SUBWOOFER_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                                    } 
                                                
                                                else 
                                                    {
                                                    __context__.SourceCodeLine = 356;
                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVSW2" , SRESPONSE ) == 1))  ) ) 
                                                        { 
                                                        __context__.SourceCodeLine = 358;
                                                        IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                                        __context__.SourceCodeLine = 359;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 9))  ) ) 
                                                            {
                                                            __context__.SourceCodeLine = 360;
                                                            IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                                            }
                                                        
                                                        __context__.SourceCodeLine = 361;
                                                        SUBWOOFER_2_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                                        } 
                                                    
                                                    else 
                                                        {
                                                        __context__.SourceCodeLine = 363;
                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVSL" , SRESPONSE ) == 1))  ) ) 
                                                            { 
                                                            __context__.SourceCodeLine = 365;
                                                            IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                                            __context__.SourceCodeLine = 366;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 8))  ) ) 
                                                                {
                                                                __context__.SourceCodeLine = 367;
                                                                IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                                                }
                                                            
                                                            __context__.SourceCodeLine = 368;
                                                            SURROUND_LEFT_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                                            } 
                                                        
                                                        else 
                                                            {
                                                            __context__.SourceCodeLine = 370;
                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVSR" , SRESPONSE ) == 1))  ) ) 
                                                                { 
                                                                __context__.SourceCodeLine = 372;
                                                                IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                                                __context__.SourceCodeLine = 373;
                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 8))  ) ) 
                                                                    {
                                                                    __context__.SourceCodeLine = 374;
                                                                    IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                                                    }
                                                                
                                                                __context__.SourceCodeLine = 375;
                                                                SURROUND_RIGHT_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                                                } 
                                                            
                                                            else 
                                                                {
                                                                __context__.SourceCodeLine = 377;
                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVSBL" , SRESPONSE ) == 1))  ) ) 
                                                                    { 
                                                                    __context__.SourceCodeLine = 379;
                                                                    IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                                                    __context__.SourceCodeLine = 380;
                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 9))  ) ) 
                                                                        {
                                                                        __context__.SourceCodeLine = 381;
                                                                        IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                                                        }
                                                                    
                                                                    __context__.SourceCodeLine = 382;
                                                                    SURROUND_BACK_LEFT_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                                                    } 
                                                                
                                                                else 
                                                                    {
                                                                    __context__.SourceCodeLine = 384;
                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVSBR" , SRESPONSE ) == 1))  ) ) 
                                                                        { 
                                                                        __context__.SourceCodeLine = 386;
                                                                        IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                                                        __context__.SourceCodeLine = 387;
                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 9))  ) ) 
                                                                            {
                                                                            __context__.SourceCodeLine = 388;
                                                                            IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                                                            }
                                                                        
                                                                        __context__.SourceCodeLine = 389;
                                                                        SURROUND_BACK_RIGHT_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                                                        } 
                                                                    
                                                                    else 
                                                                        {
                                                                        __context__.SourceCodeLine = 391;
                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVSB" , SRESPONSE ) == 1))  ) ) 
                                                                            { 
                                                                            __context__.SourceCodeLine = 393;
                                                                            IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                                                            __context__.SourceCodeLine = 394;
                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 8))  ) ) 
                                                                                {
                                                                                __context__.SourceCodeLine = 395;
                                                                                IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                                                                }
                                                                            
                                                                            __context__.SourceCodeLine = 396;
                                                                            SURROUND_BACK_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                                                            } 
                                                                        
                                                                        else 
                                                                            {
                                                                            __context__.SourceCodeLine = 398;
                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVFHL" , SRESPONSE ) == 1))  ) ) 
                                                                                { 
                                                                                __context__.SourceCodeLine = 400;
                                                                                IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                                                                __context__.SourceCodeLine = 401;
                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 9))  ) ) 
                                                                                    {
                                                                                    __context__.SourceCodeLine = 402;
                                                                                    IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                                                                    }
                                                                                
                                                                                __context__.SourceCodeLine = 403;
                                                                                FRONT_HEIGHT_LEFT_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                                                                } 
                                                                            
                                                                            else 
                                                                                {
                                                                                __context__.SourceCodeLine = 405;
                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVFHR" , SRESPONSE ) == 1))  ) ) 
                                                                                    { 
                                                                                    __context__.SourceCodeLine = 407;
                                                                                    IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                                                                    __context__.SourceCodeLine = 408;
                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 9))  ) ) 
                                                                                        {
                                                                                        __context__.SourceCodeLine = 409;
                                                                                        IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                                                                        }
                                                                                    
                                                                                    __context__.SourceCodeLine = 410;
                                                                                    FRONT_HEIGHT_RIGHT_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                                                                    } 
                                                                                
                                                                                else 
                                                                                    {
                                                                                    __context__.SourceCodeLine = 412;
                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVFWL" , SRESPONSE ) == 1))  ) ) 
                                                                                        { 
                                                                                        __context__.SourceCodeLine = 414;
                                                                                        IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                                                                        __context__.SourceCodeLine = 415;
                                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 9))  ) ) 
                                                                                            {
                                                                                            __context__.SourceCodeLine = 416;
                                                                                            IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                                                                            }
                                                                                        
                                                                                        __context__.SourceCodeLine = 417;
                                                                                        FRONT_WIDE_LEFT_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                                                                        } 
                                                                                    
                                                                                    else 
                                                                                        {
                                                                                        __context__.SourceCodeLine = 419;
                                                                                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "CVFWR" , SRESPONSE ) == 1))  ) ) 
                                                                                            { 
                                                                                            __context__.SourceCodeLine = 421;
                                                                                            IVALUE = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                                                                            __context__.SourceCodeLine = 422;
                                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Length( SRESPONSE ) == 9))  ) ) 
                                                                                                {
                                                                                                __context__.SourceCodeLine = 423;
                                                                                                IVALUE = (ushort) ( (IVALUE * 10) ) ; 
                                                                                                }
                                                                                            
                                                                                            __context__.SourceCodeLine = 424;
                                                                                            FRONT_WIDE_RIGHT_LEVEL_TEXT  .UpdateValue ( CALCULATE_LEVEL (  __context__ , (ushort)( IVALUE ))  ) ; 
                                                                                            } 
                                                                                        
                                                                                        else 
                                                                                            {
                                                                                            __context__.SourceCodeLine = 427;
                                                                                            if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "NSE" , SRESPONSE ) == 1))  ) ) 
                                                                                                { 
                                                                                                __context__.SourceCodeLine = 429;
                                                                                                SDUMP  .UpdateValue ( Functions.Remove ( "NSE" , SRESPONSE )  ) ; 
                                                                                                __context__.SourceCodeLine = 430;
                                                                                                ISTRINGNUMBER = (ushort) ( Functions.Atoi( SRESPONSE ) ) ; 
                                                                                                __context__.SourceCodeLine = 431;
                                                                                                SDUMP  .UpdateValue ( Functions.Remove ( 1, SRESPONSE )  ) ; 
                                                                                                __context__.SourceCodeLine = 433;
                                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt (ISTRINGNUMBER == 0) ) || Functions.TestForTrue ( Functions.BoolToInt (ISTRINGNUMBER == 8) )) ))  ) ) 
                                                                                                    { 
                                                                                                    __context__.SourceCodeLine = 435;
                                                                                                    SDUMP  .UpdateValue ( Functions.Left ( SRESPONSE ,  (int) ( Functions.Find( "\u000D" , SRESPONSE ) ) )  ) ; 
                                                                                                    __context__.SourceCodeLine = 436;
                                                                                                    LINE_OUT [ (ISTRINGNUMBER + 1)]  .UpdateValue ( SDUMP  ) ; 
                                                                                                    } 
                                                                                                
                                                                                                else 
                                                                                                    { 
                                                                                                    __context__.SourceCodeLine = 440;
                                                                                                    SSELECTEDCHAR  .UpdateValue ( Functions.Remove ( 1, SRESPONSE )  ) ; 
                                                                                                    __context__.SourceCodeLine = 441;
                                                                                                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Bit( SSELECTEDCHAR , (int)( 1 ) , (int)( 3 ) ) == 0))  ) ) 
                                                                                                        {
                                                                                                        __context__.SourceCodeLine = 442;
                                                                                                        HIGHLIGHT_LINE [ (ISTRINGNUMBER + 1)]  .Value = (ushort) ( 0 ) ; 
                                                                                                        }
                                                                                                    
                                                                                                    __context__.SourceCodeLine = 444;
                                                                                                    if ( Functions.TestForTrue  ( ( Bit( SSELECTEDCHAR , (int)( 1 ) , (int)( 3 ) ))  ) ) 
                                                                                                        { 
                                                                                                        __context__.SourceCodeLine = 446;
                                                                                                        HIGHLIGHT_LINE [ (ISTRINGNUMBER + 1)]  .Value = (ushort) ( 1 ) ; 
                                                                                                        } 
                                                                                                    
                                                                                                    __context__.SourceCodeLine = 448;
                                                                                                    SDUMP  .UpdateValue ( Functions.Left ( SRESPONSE ,  (int) ( (Functions.Find( "\u000D" , SRESPONSE ) - 1) ) )  ) ; 
                                                                                                    __context__.SourceCodeLine = 449;
                                                                                                    LINE_OUT [ (ISTRINGNUMBER + 1)]  .UpdateValue ( SDUMP  ) ; 
                                                                                                    } 
                                                                                                
                                                                                                } 
                                                                                            
                                                                                            else 
                                                                                                {
                                                                                                __context__.SourceCodeLine = 452;
                                                                                                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Find( "NSH" , SRESPONSE ) == 1))  ) ) 
                                                                                                    { 
                                                                                                    __context__.SourceCodeLine = 454;
                                                                                                    SDUMP  .UpdateValue ( Functions.Remove ( "NSH" , SRESPONSE )  ) ; 
                                                                                                    __context__.SourceCodeLine = 455;
                                                                                                    ISTRINGNUMBER = (ushort) ( Functions.Atoi( Functions.Left( SRESPONSE , (int)( 2 ) ) ) ) ; 
                                                                                                    __context__.SourceCodeLine = 456;
                                                                                                    SDUMP  .UpdateValue ( Functions.Remove ( 2, SRESPONSE )  ) ; 
                                                                                                    __context__.SourceCodeLine = 457;
                                                                                                    SDUMP  .UpdateValue ( Functions.Left ( SRESPONSE ,  (int) ( (Functions.Find( "\u000D" , SRESPONSE ) - 1) ) )  ) ; 
                                                                                                    __context__.SourceCodeLine = 458;
                                                                                                    NET_AUDIO_PRESET_NAME_TEXT [ (ISTRINGNUMBER + 1)]  .UpdateValue ( SDUMP  ) ; 
                                                                                                    } 
                                                                                                
                                                                                                }
                                                                                            
                                                                                            }
                                                                                        
                                                                                        }
                                                                                    
                                                                                    }
                                                                                
                                                                                }
                                                                            
                                                                            }
                                                                        
                                                                        }
                                                                    
                                                                    }
                                                                
                                                                }
                                                            
                                                            }
                                                        
                                                        }
                                                    
                                                    }
                                                
                                                }
                                            
                                            }
                                        
                                        }
                                    
                                    }
                                
                                }
                            
                            }
                        
                        }
                    
                    __context__.SourceCodeLine = 283;
                    } 
                
                __context__.SourceCodeLine = 461;
                IPROCESSFROMDEVICE = (ushort) ( 0 ) ; 
                } 
            
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler( __SignalEventArg__ ); }
        return this;
        
    }
    
public override object FunctionMain (  object __obj__ ) 
    { 
    try
    {
        SplusExecutionContext __context__ = SplusFunctionMainStartCode();
        
        __context__.SourceCodeLine = 474;
        IPROCESSFROMDEVICE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 475;
        ISEMAPHORE = (ushort) ( 0 ) ; 
        __context__.SourceCodeLine = 476;
        IMVMAX = (ushort) ( 65535 ) ; 
        
        
    }
    catch(Exception e) { ObjectCatchHandler(e); }
    finally { ObjectFinallyHandler(); }
    return __obj__;
    }
    

public override void LogosSplusInitialize()
{
    SocketInfo __socketinfo__ = new SocketInfo( 1, this );
    InitialParametersClass.ResolveHostName = __socketinfo__.ResolveHostName;
    _SplusNVRAM = new SplusNVRAM( this );
    SHDTUNERNUMBER  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 4, this );
    SHDTUNERCOMMAND  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 10, this );
    SFROMDEVICE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 5000, this );
    SRESPONSE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 125, this );
    SDUMP  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
    SSELECTEDCHAR  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 1, this );
    
    AM_SELECTED = new Crestron.Logos.SplusObjects.DigitalInput( AM_SELECTED__DigitalInput__, this );
    m_DigitalInputList.Add( AM_SELECTED__DigitalInput__, AM_SELECTED );
    
    FM_SELECTED = new Crestron.Logos.SplusObjects.DigitalInput( FM_SELECTED__DigitalInput__, this );
    m_DigitalInputList.Add( FM_SELECTED__DigitalInput__, FM_SELECTED );
    
    CLEAR = new Crestron.Logos.SplusObjects.DigitalInput( CLEAR__DigitalInput__, this );
    m_DigitalInputList.Add( CLEAR__DigitalInput__, CLEAR );
    
    HD_TUNER_KP = new InOutArray<DigitalInput>( 12, this );
    for( uint i = 0; i < 12; i++ )
    {
        HD_TUNER_KP[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( HD_TUNER_KP__DigitalInput__ + i, HD_TUNER_KP__DigitalInput__, this );
        m_DigitalInputList.Add( HD_TUNER_KP__DigitalInput__ + i, HD_TUNER_KP[i+1] );
    }
    
    HIGHLIGHT_LINE = new InOutArray<DigitalOutput>( 8, this );
    for( uint i = 0; i < 8; i++ )
    {
        HIGHLIGHT_LINE[i+1] = new Crestron.Logos.SplusObjects.DigitalOutput( HIGHLIGHT_LINE__DigitalOutput__ + i, this );
        m_DigitalOutputList.Add( HIGHLIGHT_LINE__DigitalOutput__ + i, HIGHLIGHT_LINE[i+1] );
    }
    
    MAIN_VOLUME_GAUGE = new Crestron.Logos.SplusObjects.AnalogOutput( MAIN_VOLUME_GAUGE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( MAIN_VOLUME_GAUGE__AnalogSerialOutput__, MAIN_VOLUME_GAUGE );
    
    ZONE_2_VOLUME_GAUGE = new Crestron.Logos.SplusObjects.AnalogOutput( ZONE_2_VOLUME_GAUGE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ZONE_2_VOLUME_GAUGE__AnalogSerialOutput__, ZONE_2_VOLUME_GAUGE );
    
    ZONE_3_VOLUME_GAUGE = new Crestron.Logos.SplusObjects.AnalogOutput( ZONE_3_VOLUME_GAUGE__AnalogSerialOutput__, this );
    m_AnalogOutputList.Add( ZONE_3_VOLUME_GAUGE__AnalogSerialOutput__, ZONE_3_VOLUME_GAUGE );
    
    MAIN_VOLUME_TEXT = new Crestron.Logos.SplusObjects.StringOutput( MAIN_VOLUME_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( MAIN_VOLUME_TEXT__AnalogSerialOutput__, MAIN_VOLUME_TEXT );
    
    ZONE_2_VOLUME_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ZONE_2_VOLUME_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ZONE_2_VOLUME_TEXT__AnalogSerialOutput__, ZONE_2_VOLUME_TEXT );
    
    ZONE_3_VOLUME_TEXT = new Crestron.Logos.SplusObjects.StringOutput( ZONE_3_VOLUME_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( ZONE_3_VOLUME_TEXT__AnalogSerialOutput__, ZONE_3_VOLUME_TEXT );
    
    FRONT_LEFT_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( FRONT_LEFT_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FRONT_LEFT_LEVEL_TEXT__AnalogSerialOutput__, FRONT_LEFT_LEVEL_TEXT );
    
    FRONT_RIGHT_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( FRONT_RIGHT_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FRONT_RIGHT_LEVEL_TEXT__AnalogSerialOutput__, FRONT_RIGHT_LEVEL_TEXT );
    
    CENTER_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( CENTER_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( CENTER_LEVEL_TEXT__AnalogSerialOutput__, CENTER_LEVEL_TEXT );
    
    SUBWOOFER_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( SUBWOOFER_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SUBWOOFER_LEVEL_TEXT__AnalogSerialOutput__, SUBWOOFER_LEVEL_TEXT );
    
    SUBWOOFER_2_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( SUBWOOFER_2_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SUBWOOFER_2_LEVEL_TEXT__AnalogSerialOutput__, SUBWOOFER_2_LEVEL_TEXT );
    
    SURROUND_LEFT_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( SURROUND_LEFT_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SURROUND_LEFT_LEVEL_TEXT__AnalogSerialOutput__, SURROUND_LEFT_LEVEL_TEXT );
    
    SURROUND_RIGHT_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( SURROUND_RIGHT_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SURROUND_RIGHT_LEVEL_TEXT__AnalogSerialOutput__, SURROUND_RIGHT_LEVEL_TEXT );
    
    SURROUND_BACK_LEFT_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( SURROUND_BACK_LEFT_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SURROUND_BACK_LEFT_LEVEL_TEXT__AnalogSerialOutput__, SURROUND_BACK_LEFT_LEVEL_TEXT );
    
    SURROUND_BACK_RIGHT_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( SURROUND_BACK_RIGHT_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SURROUND_BACK_RIGHT_LEVEL_TEXT__AnalogSerialOutput__, SURROUND_BACK_RIGHT_LEVEL_TEXT );
    
    SURROUND_BACK_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( SURROUND_BACK_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( SURROUND_BACK_LEVEL_TEXT__AnalogSerialOutput__, SURROUND_BACK_LEVEL_TEXT );
    
    FRONT_HEIGHT_LEFT_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( FRONT_HEIGHT_LEFT_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FRONT_HEIGHT_LEFT_LEVEL_TEXT__AnalogSerialOutput__, FRONT_HEIGHT_LEFT_LEVEL_TEXT );
    
    FRONT_HEIGHT_RIGHT_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( FRONT_HEIGHT_RIGHT_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FRONT_HEIGHT_RIGHT_LEVEL_TEXT__AnalogSerialOutput__, FRONT_HEIGHT_RIGHT_LEVEL_TEXT );
    
    FRONT_WIDE_LEFT_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( FRONT_WIDE_LEFT_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FRONT_WIDE_LEFT_LEVEL_TEXT__AnalogSerialOutput__, FRONT_WIDE_LEFT_LEVEL_TEXT );
    
    FRONT_WIDE_RIGHT_LEVEL_TEXT = new Crestron.Logos.SplusObjects.StringOutput( FRONT_WIDE_RIGHT_LEVEL_TEXT__AnalogSerialOutput__, this );
    m_StringOutputList.Add( FRONT_WIDE_RIGHT_LEVEL_TEXT__AnalogSerialOutput__, FRONT_WIDE_RIGHT_LEVEL_TEXT );
    
    TUNER_FREQUENCY = new Crestron.Logos.SplusObjects.StringOutput( TUNER_FREQUENCY__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TUNER_FREQUENCY__AnalogSerialOutput__, TUNER_FREQUENCY );
    
    TO_DEVICE = new Crestron.Logos.SplusObjects.StringOutput( TO_DEVICE__AnalogSerialOutput__, this );
    m_StringOutputList.Add( TO_DEVICE__AnalogSerialOutput__, TO_DEVICE );
    
    LINE_OUT = new InOutArray<StringOutput>( 9, this );
    for( uint i = 0; i < 9; i++ )
    {
        LINE_OUT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( LINE_OUT__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( LINE_OUT__AnalogSerialOutput__ + i, LINE_OUT[i+1] );
    }
    
    NET_AUDIO_PRESET_NAME_TEXT = new InOutArray<StringOutput>( 40, this );
    for( uint i = 0; i < 40; i++ )
    {
        NET_AUDIO_PRESET_NAME_TEXT[i+1] = new Crestron.Logos.SplusObjects.StringOutput( NET_AUDIO_PRESET_NAME_TEXT__AnalogSerialOutput__ + i, this );
        m_StringOutputList.Add( NET_AUDIO_PRESET_NAME_TEXT__AnalogSerialOutput__ + i, NET_AUDIO_PRESET_NAME_TEXT[i+1] );
    }
    
    FROM_DEVICE = new Crestron.Logos.SplusObjects.BufferInput( FROM_DEVICE__AnalogSerialInput__, 50000, this );
    m_StringInputList.Add( FROM_DEVICE__AnalogSerialInput__, FROM_DEVICE );
    
    RESPONSE_NSE = new Crestron.Logos.SplusObjects.BufferInput( RESPONSE_NSE__AnalogSerialInput__, 125, this );
    m_StringInputList.Add( RESPONSE_NSE__AnalogSerialInput__, RESPONSE_NSE );
    
    
    for( uint i = 0; i < 12; i++ )
        HD_TUNER_KP[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( HD_TUNER_KP_OnPush_0, false ) );
        
    FROM_DEVICE.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_DEVICE_OnChange_1, false ) );
    
    _SplusNVRAM.PopulateCustomAttributeList( true );
    
    NVRAM = _SplusNVRAM;
    
}

public override void LogosSimplSharpInitialize()
{
    
    
}

public CrestronModuleClass_MARANTZ_AV7702_PROCESSOR_V1_0 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}




const uint FROM_DEVICE__AnalogSerialInput__ = 0;
const uint AM_SELECTED__DigitalInput__ = 0;
const uint FM_SELECTED__DigitalInput__ = 1;
const uint CLEAR__DigitalInput__ = 2;
const uint HD_TUNER_KP__DigitalInput__ = 3;
const uint RESPONSE_NSE__AnalogSerialInput__ = 1;
const uint HIGHLIGHT_LINE__DigitalOutput__ = 0;
const uint MAIN_VOLUME_TEXT__AnalogSerialOutput__ = 0;
const uint MAIN_VOLUME_GAUGE__AnalogSerialOutput__ = 1;
const uint ZONE_2_VOLUME_TEXT__AnalogSerialOutput__ = 2;
const uint ZONE_2_VOLUME_GAUGE__AnalogSerialOutput__ = 3;
const uint ZONE_3_VOLUME_TEXT__AnalogSerialOutput__ = 4;
const uint ZONE_3_VOLUME_GAUGE__AnalogSerialOutput__ = 5;
const uint FRONT_LEFT_LEVEL_TEXT__AnalogSerialOutput__ = 6;
const uint FRONT_RIGHT_LEVEL_TEXT__AnalogSerialOutput__ = 7;
const uint CENTER_LEVEL_TEXT__AnalogSerialOutput__ = 8;
const uint SUBWOOFER_LEVEL_TEXT__AnalogSerialOutput__ = 9;
const uint SUBWOOFER_2_LEVEL_TEXT__AnalogSerialOutput__ = 10;
const uint SURROUND_LEFT_LEVEL_TEXT__AnalogSerialOutput__ = 11;
const uint SURROUND_RIGHT_LEVEL_TEXT__AnalogSerialOutput__ = 12;
const uint SURROUND_BACK_LEFT_LEVEL_TEXT__AnalogSerialOutput__ = 13;
const uint SURROUND_BACK_RIGHT_LEVEL_TEXT__AnalogSerialOutput__ = 14;
const uint SURROUND_BACK_LEVEL_TEXT__AnalogSerialOutput__ = 15;
const uint FRONT_HEIGHT_LEFT_LEVEL_TEXT__AnalogSerialOutput__ = 16;
const uint FRONT_HEIGHT_RIGHT_LEVEL_TEXT__AnalogSerialOutput__ = 17;
const uint FRONT_WIDE_LEFT_LEVEL_TEXT__AnalogSerialOutput__ = 18;
const uint FRONT_WIDE_RIGHT_LEVEL_TEXT__AnalogSerialOutput__ = 19;
const uint TUNER_FREQUENCY__AnalogSerialOutput__ = 20;
const uint TO_DEVICE__AnalogSerialOutput__ = 21;
const uint LINE_OUT__AnalogSerialOutput__ = 22;
const uint NET_AUDIO_PRESET_NAME_TEXT__AnalogSerialOutput__ = 31;

[SplusStructAttribute(-1, true, false)]
public class SplusNVRAM : SplusStructureBase
{

    public SplusNVRAM( SplusObject __caller__ ) : base( __caller__ ) {}
    
    
}

SplusNVRAM _SplusNVRAM = null;

public class __CEvent__ : CEvent
{
    public __CEvent__() {}
    public void Close() { base.Close(); }
    public int Reset() { return base.Reset() ? 1 : 0; }
    public int Set() { return base.Set() ? 1 : 0; }
    public int Wait( int timeOutInMs ) { return base.Wait( timeOutInMs ) ? 1 : 0; }
}
public class __CMutex__ : CMutex
{
    public __CMutex__() {}
    public void Close() { base.Close(); }
    public void ReleaseMutex() { base.ReleaseMutex(); }
    public int WaitForMutex() { return base.WaitForMutex() ? 1 : 0; }
}
 public int IsNull( object obj ){ return (obj == null) ? 1 : 0; }
}


}
