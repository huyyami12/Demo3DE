﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------
Imports System
Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports DevExpress.Data.Filtering
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Reflection
Namespace Demo3

    Partial Public Class ChiTietDonNhapHang
        Inherits XPObject
        Dim fid_chitietdonnhaphang As String
        Public Property id_chitietdonnhaphang() As String
            Get
                Return fid_chitietdonnhaphang
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)(NameOf(id_chitietdonnhaphang), fid_chitietdonnhaphang, value)
            End Set
        End Property
        Dim fid_donnhap As DonNhapHangs
        <Association("ChiTietDonNhapHangReferencesDonNhapHangs")>
        Public Property id_donnhap() As DonNhapHangs
            Get
                Return fid_donnhap
            End Get
            Set(ByVal value As DonNhapHangs)
                SetPropertyValue(Of DonNhapHangs)(NameOf(id_donnhap), fid_donnhap, value)
            End Set
        End Property
    End Class

End Namespace
