namespace Thetis
{
    #region Enums

    public enum FocusMasterMode
    {
        None = 0,
        Logger,
        Click,
        Title,
    }

    public enum FWCAnt
    {
        NC = 0,
        ANT1,
        ANT2,
        ANT3,
        RX1IN,
        RX2IN,
        RX1TAP,
        SIG_GEN,
    }

    public enum ColorSheme
    {
        original = 0,
        enhanced,
        SPECTRAN,
        BLACKWHITE,
        LinLog,
        LinRad,
        LinAuto,
        off,
    }

    public enum MultiMeterDisplayMode
    {
        Original = 0,
        Edge,
        Analog,
    }
    public enum MultiMeterMeasureMode
    {
        FIRST = -1,
        SMeter,
        DBM,
        UV,
        LAST
    }

    public enum FilterWidthMode
    {
        Linear = 0,
        Log,
        Log10,
    }

    public enum DisplayEngine
    {
        GDI_PLUS = 0,
        DIRECT_X,
    }

    public enum Model
    {
        HPSDR = 0,
        HERMES,
        ANAN10,
        ANAN10E,
        ANAN100,
        ANAN100B,
        ANAN100D,
        ANAN200D,
        ORIONMKII,
        ANAN7000D,
        ANAN8000D,
        ANAN_G2,        //G8NJJ
        ANAN_G2_1K,     //G8NJJ
        ANVELINAPRO3,
        HERMESLITE,     //MI0BOT
        LAST
    }

    public enum HPSDRModel
    {
        FIRST = -1,
        HPSDR,
        HERMES,
        ANAN10,
        ANAN10E,
        ANAN100,
        ANAN100B,
        ANAN100D,
        ANAN200D,
        ORIONMKII,
        ANAN7000D,
        ANAN8000D,
        ANAN_G2,        //G8NJJ
        ANAN_G2_1K,     //G8NJJ
        ANVELINAPRO3,
        HERMESLITE,     //MI0BOT
        LAST
    }

    public enum DisplayMode
    {
        FIRST = -1,
        SPECTRUM,
        PANADAPTER,
        SCOPE,
        SCOPE2,
        PHASE,
        PHASE2,
        WATERFALL,
        HISTOGRAM,
        PANAFALL,
        PANASCOPE,
        SPECTRASCOPE,
        OFF,
        LAST,
    }

    public enum AGCMode
    {
        FIRST = -1,
        FIXD,
        LONG,
        SLOW,
        MED,
        FAST,
        CUSTOM,
        LAST,
    }

    public enum MeterRXMode
    {
        FIRST = -1,
        SIGNAL_STRENGTH,
        SIGNAL_AVERAGE,
        ADC_L,
        ADC_R,
        ADC2_L,
        ADC2_R,
        OFF,
        LAST,
    }

    public enum MeterTXMode
    {
        FIRST = -1,
        FORWARD_POWER,
        REVERSE_POWER,
        SWR_POWER,
        MIC,
        EQ,
        LEVELER,
        LVL_G,
        CFC_PK,
        CFC_G,
        COMP,
        ALC,
        ALC_G,
        ALC_GROUP,
        SWR,
        OFF,
        LAST,
    }

    public enum KeyerLine
    {
        None = 0,
        DTR,
        RTS,
    }

    public enum FRSRegion
    {
        FIRST = -1,
        US = 0,
        Spain = 1,
        Europe = 2,
        UK = 3,
        Italy_Plus = 4,
        Japan = 5,
        Australia = 6,
        Norway = 7,
        Denmark = 8,
        Latvia = 9,
        Slovakia = 10,
        Bulgaria = 11,
        Greece = 12,
        Hungary = 13,
        Netherlands = 14,
        France = 15,
        Russia = 16,
        Israel = 17,
        Extended = 18,
        India = 19,
        Sweden = 20,
        Region1 = 21,
        Region2 = 22,
        Region3 = 23,
        Germany = 24,
        LAST,
    }

    public enum PreampMode
    {
        FIRST = -1,
        HPSDR_OFF,
        HPSDR_ON,
        HPSDR_MINUS10,
        HPSDR_MINUS20,
        HPSDR_MINUS30,
        HPSDR_MINUS40,
        HPSDR_MINUS50,
        SA_MINUS10,
        SA_MINUS20,  //MW0LGE_21d
        SA_MINUS30,
        // STEP_ATTEN,
        LAST,
    }

    public enum DSPMode
    {
        FIRST = -1,
        LSB,
        USB,
        DSB,
        CWL,
        CWU,
        FM,
        AM,
        DIGU,
        SPEC,
        DIGL,
        SAM,
        DRM,
        AM_LSB,
        AM_USB,
        LAST,
    }

    public enum Band
    {
        FIRST = -1,
        GEN,

        //B2200M, //MW0LGE_21k8 need fix this
        //B600M,

        B160M,
        B80M,
        B60M,
        B40M,
        B30M,
        B20M,
        B17M,
        B15M,
        B12M,
        B10M,
        B6M,
        B2M,
        WWV,

        VHF0,
        VHF1,
        VHF2,
        VHF3,
        VHF4,
        VHF5,
        VHF6,
        VHF7,
        VHF8,
        VHF9,
        VHF10,
        VHF11,
        VHF12,
        VHF13,

        BLMF, // ke9ns move down below vhf
        B120M,
        B90M,
        B61M,
        B49M,
        B41M,
        B31M,
        B25M,
        B22M,
        B19M,
        B16M,
        B14M,
        B13M,
        B11M,

        LAST,
    }

    public enum Filter
    {
        FIRST = -1,
        F1,
        F2,
        F3,
        F4,
        F5,
        F6,
        F7,
        F8,
        F9,
        F10,
        VAR1,
        VAR2,
        NONE,
        LAST,
    }

    public enum PTTMode
    {
        FIRST = -1,
        NONE,
        MANUAL,
        MIC,
        CW,
        X2,
        CAT,
        VOX,
        SPACE,
        TCI,
        LAST,
    }

    public enum DisplayLabelAlignment
    {
        FIRST = -1,
        LEFT,
        CENTER,
        RIGHT,
        AUTO,
        OFF,
        LAST,
    }

    public enum ClickTuneMode
    {
        Off = 0,
        VFOA,
        VFOB,
        //VFOAC,
    }

    public enum FMTXMode
    {
        // Order is chosen carefully here for memory form -- take care before rearranging
        High = 0,   // +
        Simplex,    // S
        Low,        // -     
    }

    public enum HPSDRHW
    {
        Atlas = 0,
        Hermes = 1,
        HermesII = 2,       // ANAN-10E ANAN-100B HeremesII
        Angelia = 3,        // ANAN-100D
        Orion = 4,          // ANAN-200D
        OrionMKII = 5,      // AMAM-7000DLE 7000DLEMkII ANAN-8000DLE OrionMkII Anvelina-Pro3
        HermesLite = 6,     // HermesLite 2 added MI0BOT
        Saturn = 10,        // ANAN-G2: added G8NJJ
        Unknown = 999,      //MW0LGE
    }

    public enum DSPFilterType
    {
        Linear_Phase = 0,
        Low_Latency = 1,
    }

    public enum DisplayRegion
    {
        freqScalePanadapterRegion,
        panadapterRegion,
        dBmScalePanadapterRegion,
        waterfallRegion,
        filterRegion,
        filterRegionLow,
        filterRegionHigh,
        agcButtonRegion,
        agcThresholdLine,
        agcHangLine,
        agcFixedGainLine,
        //lockedPanButtonRegion,
        //vfoToMidButtonRegion,
        //midToVfoButtonRegion,
        //clickVfoButtonRegion,
        elsewhere
    }

    public enum BreakIn
    {
        Manual,
        Semi,
        QSK
    }

    public enum RadioProtocol
    {
        USB = 0,  // Protocol USB (P1)
        ETH,      // Protocol ETH (P2)
        Auto,
        None
    }

    public enum TXPinActions
    {
        FIRST = -1,
        MOX,
        TUNE,
        TWOTONE,
        MOX_TUNE,
        MOX_TWOTONE,
        TUNE_TWOTONE,
        MOX_TUNE_TWOTONE,
        LAST
    }

    public enum DrivePowerSource
    {
        DRIVE_SLIDER = 0,
        TUNE_SLIDER = 1,
        FIXED = 2
    }

    public enum SquelchState
    {
        OFF = 0,
        SQL = 1,
        VSQL = 2
    }

    public enum StatusBarIconGroup
    {
        All = 0,
        CMAsio,
        N1MM,
        TCPIPCat,
        SerialCat,
        TCI
    }
    #endregion
}