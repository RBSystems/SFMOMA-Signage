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

namespace UserModule_WOL
{
    public class UserModuleClass_WOL : SplusObject
    {
        static CCriticalSection g_criticalSection = new CCriticalSection();
        
        
        
        
        InOutArray<Crestron.Logos.SplusObjects.DigitalInput> SEND_WOL;
        Crestron.Logos.SplusObjects.StringOutput WOL__DOLLAR__;
        InOutArray<StringParameter> MAC_ADDRESS;
        CrestronString FF;
        private CrestronString CREATEWOLSTRING (  SplusExecutionContext __context__, CrestronString MACADDRESS ) 
            { 
            CrestronString WOLSTRING;
            WOLSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
            
            ushort I = 0;
            
            
            __context__.SourceCodeLine = 135;
            WOLSTRING  .UpdateValue ( FF  ) ; 
            __context__.SourceCodeLine = 136;
            ushort __FN_FORSTART_VAL__1 = (ushort) ( 1 ) ;
            ushort __FN_FOREND_VAL__1 = (ushort)16; 
            int __FN_FORSTEP_VAL__1 = (int)1; 
            for ( I  = __FN_FORSTART_VAL__1; (__FN_FORSTEP_VAL__1 > 0)  ? ( (I  >= __FN_FORSTART_VAL__1) && (I  <= __FN_FOREND_VAL__1) ) : ( (I  <= __FN_FORSTART_VAL__1) && (I  >= __FN_FOREND_VAL__1) ) ; I  += (ushort)__FN_FORSTEP_VAL__1) 
                { 
                __context__.SourceCodeLine = 138;
                WOLSTRING  .UpdateValue ( WOLSTRING + MACADDRESS  ) ; 
                __context__.SourceCodeLine = 136;
                } 
            
            __context__.SourceCodeLine = 140;
            return ( WOLSTRING ) ; 
            
            }
            
        object SEND_WOL_OnPush_0 ( Object __EventInfo__ )
        
            { 
            Crestron.Logos.SplusObjects.SignalEventArgs __SignalEventArg__ = (Crestron.Logos.SplusObjects.SignalEventArgs)__EventInfo__;
            try
            {
                SplusExecutionContext __context__ = SplusThreadStartCode(__SignalEventArg__);
                CrestronString WHICH_MAC;
                WHICH_MAC  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 6, this );
                
                CrestronString WOLSTRING;
                WOLSTRING  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 255, this );
                
                
                __context__.SourceCodeLine = 176;
                WHICH_MAC  .UpdateValue ( MAC_ADDRESS [ Functions.GetLastModifiedArrayIndex( __SignalEventArg__ ) ]  ) ; 
                __context__.SourceCodeLine = 177;
                WOLSTRING  .UpdateValue ( CREATEWOLSTRING (  __context__ , WHICH_MAC)  ) ; 
                __context__.SourceCodeLine = 178;
                WOL__DOLLAR__  .UpdateValue ( WOLSTRING  ) ; 
                
                
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
            
            __context__.SourceCodeLine = 241;
            FF  .UpdateValue ( "\u00FF\u00FF\u00FF\u00FF\u00FF\u00FF"  ) ; 
            
            
        }
        catch(Exception e) { ObjectCatchHandler(e); }
        finally { ObjectFinallyHandler(); }
        return __obj__;
        }
        
    
    public override void LogosSplusInitialize()
    {
        _SplusNVRAM = new SplusNVRAM( this );
        FF  = new CrestronString( Crestron.Logos.SplusObjects.CrestronStringEncoding.eEncodingASCII, 6, this );
        
        SEND_WOL = new InOutArray<DigitalInput>( 16, this );
        for( uint i = 0; i < 16; i++ )
        {
            SEND_WOL[i+1] = new Crestron.Logos.SplusObjects.DigitalInput( SEND_WOL__DigitalInput__ + i, SEND_WOL__DigitalInput__, this );
            m_DigitalInputList.Add( SEND_WOL__DigitalInput__ + i, SEND_WOL[i+1] );
        }
        
        WOL__DOLLAR__ = new Crestron.Logos.SplusObjects.StringOutput( WOL__DOLLAR____AnalogSerialOutput__, this );
        m_StringOutputList.Add( WOL__DOLLAR____AnalogSerialOutput__, WOL__DOLLAR__ );
        
        MAC_ADDRESS = new InOutArray<StringParameter>( 16, this );
        for( uint i = 0; i < 16; i++ )
        {
            MAC_ADDRESS[i+1] = new StringParameter( MAC_ADDRESS__Parameter__ + i, MAC_ADDRESS__Parameter__, this );
            m_ParameterList.Add( MAC_ADDRESS__Parameter__ + i, MAC_ADDRESS[i+1] );
        }
        
        
        for( uint i = 0; i < 16; i++ )
            SEND_WOL[i+1].OnDigitalPush.Add( new InputChangeHandlerWrapper( SEND_WOL_OnPush_0, false ) );
            
        
        _SplusNVRAM.PopulateCustomAttributeList( true );
        
        NVRAM = _SplusNVRAM;
        
    }
    
    public override void LogosSimplSharpInitialize()
    {
        
        
    }
    
    public UserModuleClass_WOL ( string InstanceName, string ReferenceID, Crestron.Logos.SplusObjects.CrestronStringEncoding nEncodingType ) : base( InstanceName, ReferenceID, nEncodingType ) {}
    
    
    
    
    const uint SEND_WOL__DigitalInput__ = 0;
    const uint WOL__DOLLAR____AnalogSerialOutput__ = 0;
    const uint MAC_ADDRESS__Parameter__ = 10;
    
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
