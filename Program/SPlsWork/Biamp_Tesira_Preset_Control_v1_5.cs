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

namespace UserModule_BIAMP_TESIRA_PRESET_CONTROL_V1_5
{
    public class UserModuleClass_BIAMP_TESIRA_PRESET_CONTROL_V1_5 : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        
        
        Crestron.Logos.SplusObjects.DigitalInput RECALL_PRESET;
        Crestron.Logos.SplusObjects.StringInput PRESET_NAME_NUMBER;
        Crestron.Logos.SplusObjects.BufferInput FROM_PROCESSOR__DOLLAR__;
        Crestron.Logos.SplusObjects.DigitalOutput IS_INITIALIZED;
        Crestron.Logos.SplusObjects.StringOutput TO_PROCESSOR__DOLLAR__;
        ushort MYID = 0;
        ushort PARSINGMODULEBUSY = 0;
        CrestronString PARSEDMODULEMSG;
        ushort RESPONSEMODULEMSGID = 0;
        CrestronString RESPONSEREQUESTMSG;
        CrestronString RESPONSEMSG;
        CrestronString PARSEVALUE;
        ushort HASSUBSCRIPTIONREGISTERED = 0;
        CrestronString TRASH;
        private CrestronString GETBOUNDSTRING (  SplusExecutionContext __context__, CrestronString SOURCE , CrestronString STARTSTRING , CrestronString ENDSTRING ) 
            { 
            ushort STARTINDEX = 0;
            
            ushort ENDINDEX = 0;
            
            CrestronString RESPONSE;
            RESPONSE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
            
            
            __context__.SourceCodeLine = 114;
            RESPONSE  .UpdateValue ( ""  ) ; 
            __context__.SourceCodeLine = 116;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( SOURCE ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 118;
                STARTINDEX = (ushort) ( Functions.Find( STARTSTRING , SOURCE ) ) ; 
                __context__.SourceCodeLine = 119;
                ENDINDEX = (ushort) ( Functions.Find( ENDSTRING , SOURCE , (STARTINDEX + 1) ) ) ; 
                __context__.SourceCodeLine = 121;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( (Functions.TestForTrue ( Functions.BoolToInt ( STARTINDEX > 0 ) ) && Functions.TestForTrue ( Functions.BoolToInt ( STARTINDEX < ENDINDEX ) )) ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 123;
                    STARTINDEX = (ushort) ( (STARTINDEX + Functions.Length( STARTSTRING )) ) ; 
                    __context__.SourceCodeLine = 125;
                    RESPONSE  .UpdateValue ( Functions.Mid ( SOURCE ,  (int) ( STARTINDEX ) ,  (int) ( (ENDINDEX - STARTINDEX) ) )  ) ; 
                    } 
                
                } 
            
            __context__.SourceCodeLine = 129;
            return ( RESPONSE ) ; 
            
            }
            
        private ushort STARTSWITH (  SplusExecutionContext __context__, CrestronString MATCH_STRING , CrestronString SOURCE_STRING ) 
            { 
            
            __context__.SourceCodeLine = 137;
            return (ushort)( Functions.BoolToInt (Functions.Find( MATCH_STRING , SOURCE_STRING ) == 1)) ; 
            
            }
            
        private ushort CONTAINS (  SplusExecutionContext __context__, CrestronString MATCH_STRING , CrestronString SOURCE_STRING ) 
            { 
            
            __context__.SourceCodeLine = 142;
            return (ushort)( Functions.BoolToInt ( Functions.Find( MATCH_STRING , SOURCE_STRING ) > 0 )) ; 
            
            }
            
        private ushort ATOI_SIGNED (  SplusExecutionContext __context__, CrestronString VALUE ) 
            { 
            
            __context__.SourceCodeLine = 147;
            if ( Functions.TestForTrue  ( ( STARTSWITH( __context__ , "-" , VALUE ))  ) ) 
                {
                __context__.SourceCodeLine = 148;
                return (ushort)( (0 - Functions.Atoi( VALUE ))) ; 
                }
            
            else 
                {
                __context__.SourceCodeLine = 150;
                return (ushort)( Functions.Atoi( VALUE )) ; 
                }
            
            
            return 0; // default return value (none specified in module)
            }
            
        private CrestronString TRIM (  SplusExecutionContext __context__, CrestronString VALUE ) 
            { 
            
            __context__.SourceCodeLine = 155;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Left( VALUE , (int)( 1 ) ) == "\u0020"))  ) ) 
                {
                __context__.SourceCodeLine = 156;
                VALUE  .UpdateValue ( Functions.Right ( VALUE ,  (int) ( (Functions.Length( VALUE ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 155;
                }
            
            __context__.SourceCodeLine = 158;
            while ( Functions.TestForTrue  ( ( Functions.BoolToInt (Functions.Right( VALUE , (int)( 1 ) ) == "\u0020"))  ) ) 
                {
                __context__.SourceCodeLine = 159;
                VALUE  .UpdateValue ( Functions.Left ( VALUE ,  (int) ( (Functions.Length( VALUE ) - 1) ) )  ) ; 
                __context__.SourceCodeLine = 158;
                }
            
            __context__.SourceCodeLine = 161;
            return ( VALUE ) ; 
            
            }
            
        private void PROCESSPROCESSORMSG (  SplusExecutionContext __context__ ) 
            { 
            
            __context__.SourceCodeLine = 172;
            if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( PARSEDMODULEMSG ) > 0 ))  ) ) 
                { 
                __context__.SourceCodeLine = 174;
                if ( Functions.TestForTrue  ( ( STARTSWITH( __context__ , "REGISTER" , PARSEDMODULEMSG ))  ) ) 
                    { 
                    __context__.SourceCodeLine = 176;
                    IS_INITIALIZED  .Value = (ushort) ( 0 ) ; 
                    __context__.SourceCodeLine = 178;
                    MYID = (ushort) ( Functions.Atoi( GETBOUNDSTRING( __context__ , PARSEDMODULEMSG , "<" , ">" ) ) ) ; 
                    __context__.SourceCodeLine = 180;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( MYID > 0 ))  ) ) 
                        {
                        __context__.SourceCodeLine = 181;
                        MakeString ( TO_PROCESSOR__DOLLAR__ , "REGISTER<{0:d}>", (short)MYID) ; 
                        }
                    
                    } 
                
                else 
                    {
                    __context__.SourceCodeLine = 183;
                    if ( Functions.TestForTrue  ( ( STARTSWITH( __context__ , "INIT" , PARSEDMODULEMSG ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 185;
                        IS_INITIALIZED  .Value = (ushort) ( 1 ) ; 
                        __context__.SourceCodeLine = 187;
                        MakeString ( TO_PROCESSOR__DOLLAR__ , "INIT_DONE<{0:d}>", (short)MYID) ; 
                        } 
                    
                    else 
                        {
                        __context__.SourceCodeLine = 189;
                        if ( Functions.TestForTrue  ( ( STARTSWITH( __context__ , "RESPONSE_MSG" , PARSEDMODULEMSG ))  ) ) 
                            { 
                            __context__.SourceCodeLine = 191;
                            RESPONSEREQUESTMSG  .UpdateValue ( GETBOUNDSTRING (  __context__ , PARSEDMODULEMSG, "<", "|")  ) ; 
                            __context__.SourceCodeLine = 192;
                            RESPONSEMSG  .UpdateValue ( GETBOUNDSTRING (  __context__ , PARSEDMODULEMSG, "|", ">")  ) ; 
                            __context__.SourceCodeLine = 194;
                            MakeString ( TO_PROCESSOR__DOLLAR__ , "RESPONSE_OK<{0:d}|{1}>", (short)MYID, RESPONSEREQUESTMSG ) ; 
                            } 
                        
                        }
                    
                    }
                
                } 
            
            
            }
            
        object FROM_PROCESSOR__DOLLAR___OnChange_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                
                __context__.SourceCodeLine = 202;
                while ( Functions.TestForTrue  ( ( 1)  ) ) 
                    { 
                    __context__.SourceCodeLine = 204;
                    try 
                        { 
                        __context__.SourceCodeLine = 206;
                        PARSEDMODULEMSG  .UpdateValue ( Functions.Gather ( ">" , FROM_PROCESSOR__DOLLAR__ )  ) ; 
                        __context__.SourceCodeLine = 208;
                        if ( Functions.TestForTrue  ( ( CONTAINS( __context__ , PARSEDMODULEMSG , FROM_PROCESSOR__DOLLAR__ ))  ) ) 
                            {
                            __context__.SourceCodeLine = 209;
                            Functions.ClearBuffer ( FROM_PROCESSOR__DOLLAR__ ) ; 
                            }
                        
                        __context__.SourceCodeLine = 211;
                        PROCESSPROCESSORMSG (  __context__  ) ; 
                        } 
                    
                    catch (Exception __splus_exception__)
                        { 
                        SimplPlusException __splus_exceptionobj__ = new SimplPlusException(__splus_exception__, this );
                        
                        __context__.SourceCodeLine = 215;
                        Print( "Issue with Processor message handeling\r\n") ; 
                        
                        }
                        
                        __context__.SourceCodeLine = 202;
                        } 
                    
                    
                    
                }
                catch(Exception e) { ObjectCatchHandler(e); }
                finally { ObjectFinallyHandler( __SignalEventArg__ ); }
                return this;
                
            }
            
        
        object RECALL_PRESET_OnPush_1 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                CrestronString OUTGOINGMSG;
                OUTGOINGMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 100, this );
                
                ushort NPRESETVALUE = 0;
                
                
                __context__.SourceCodeLine = 247;
                if ( Functions.TestForTrue  ( ( Functions.BoolToInt (IS_INITIALIZED  .Value == 1))  ) ) 
                    { 
                    __context__.SourceCodeLine = 249;
                    if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( Functions.Length( PRESET_NAME_NUMBER ) > 0 ))  ) ) 
                        { 
                        __context__.SourceCodeLine = 251;
                        NPRESETVALUE = (ushort) ( Functions.Atoi( PRESET_NAME_NUMBER ) ) ; 
                        __context__.SourceCodeLine = 253;
                        if ( Functions.TestForTrue  ( ( Functions.BoolToInt ( NPRESETVALUE >= 1001 ))  ) ) 
                            {
                            __context__.SourceCodeLine = 254;
                            MakeString ( OUTGOINGMSG , "DEVICE recallPreset {0:d}", (short)NPRESETVALUE) ; 
                            }
                        
                        else 
                            {
                            __context__.SourceCodeLine = 256;
                            MakeString ( OUTGOINGMSG , "DEVICE recallPresetByName {0}", PRESET_NAME_NUMBER ) ; 
                            }
                        
                        __context__.SourceCodeLine = 258;
                        MakeString ( TO_PROCESSOR__DOLLAR__ , "COMMAND_MSG<{0:d}|{1}>", (short)MYID, OUTGOINGMSG ) ; 
                        } 
                    
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
            
            __context__.SourceCodeLine = 271;
            PARSINGMODULEBUSY = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 273;
            IS_INITIALIZED  .Value = (ushort) ( 0 ) ; 
            __context__.SourceCodeLine = 274;
            HASSUBSCRIPTIONREGISTERED = (ushort) ( 0 ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        PARSEDMODULEMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 254, this );
        RESPONSEREQUESTMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
        RESPONSEMSG  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
        PARSEVALUE  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
        TRASH  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 150, this );
        
        RECALL_PRESET = new Crestron.Logos.SplusObjects.DigitalInput( RECALL_PRESET__DigitalInput__, this );
        m_DigitalInputList.Add( RECALL_PRESET__DigitalInput__, RECALL_PRESET );
        
        IS_INITIALIZED = new Crestron.Logos.SplusObjects.DigitalOutput( IS_INITIALIZED__DigitalOutput__, this );
        m_DigitalOutputList.Add( IS_INITIALIZED__DigitalOutput__, IS_INITIALIZED );
        
        PRESET_NAME_NUMBER = new Crestron.Logos.SplusObjects.StringInput( PRESET_NAME_NUMBER__AnalogSerialInput__, 50, this );
        m_StringInputList.Add( PRESET_NAME_NUMBER__AnalogSerialInput__, PRESET_NAME_NUMBER );
        
        TO_PROCESSOR__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( TO_PROCESSOR__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( TO_PROCESSOR__DOLLAR____AnalogSerialOutput__, TO_PROCESSOR__DOLLAR__ );
        
        FROM_PROCESSOR__DOLLAR__ = new Crestron.Logos.SplusObjects.BufferInput( FROM_PROCESSOR__DOLLAR____AnalogSerialInput__, 1024, this );
        m_StringInputList.Add( FROM_PROCESSOR__DOLLAR____AnalogSerialInput__, FROM_PROCESSOR__DOLLAR__ );
        
        
        FROM_PROCESSOR__DOLLAR__.OnSerialChange.Add( new InputChangeHandlerWrapper( FROM_PROCESSOR__DOLLAR___OnChange_0, true ) );
        RECALL_PRESET.OnDigitalPush.Add( new InputChangeHandlerWrapper( RECALL_PRESET_OnPush_1, false ) );
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_BIAMP_TESIRA_PRESET_CONTROL_V1_5 ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint RECALL_PRESET__DigitalInput__ = 0;
    const uint PRESET_NAME_NUMBER__AnalogSerialInput__ = 0;
    const uint FROM_PROCESSOR__DOLLAR____AnalogSerialInput__ = 1;
    const uint IS_INITIALIZED__DigitalOutput__ = 0;
    const uint TO_PROCESSOR__DOLLAR____AnalogSerialOutput__ = 0;
    
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
