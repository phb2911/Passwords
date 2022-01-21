Option Explicit On
Option Strict On

Public Class DataCollection
    Implements ICollection
    Implements IEnumerable
    Implements IList

    Dim _items As New ArrayList

    Private Sub CopyTo(ByVal array As System.Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo

    End Sub

    Public Sub CopyTo(ByVal array As PasswordData(), ByVal index As Integer)
        Me._items.CopyTo(array, index)
    End Sub

    Public Sub CopyTo(ByVal array As PasswordData())
        Me._items.CopyTo(array)
    End Sub

    Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
        Get
            Return Me._items.Count
        End Get
    End Property

    Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
        Get
            Return Me._items.IsSynchronized
        End Get
    End Property

    Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
        Get
            Return Me._items.SyncRoot
        End Get
    End Property

    Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
        Return Me._items.GetEnumerator
    End Function

    Private Function Add(ByVal value As Object) As Integer Implements System.Collections.IList.Add

    End Function

    Public Function Add(ByVal value As PasswordData) As Integer
        Return Me._items.Add(value)
    End Function

    Public Sub Clear() Implements System.Collections.IList.Clear
        Me._items.Clear()
    End Sub

    Private Function Contains(ByVal value As Object) As Boolean Implements System.Collections.IList.Contains

    End Function

    Private Function Contains(ByVal value As PasswordData) As Boolean
        Return Me._items.Contains(value)
    End Function

    Private Function IndexOf(ByVal value As Object) As Integer Implements System.Collections.IList.IndexOf

    End Function

    Public Function IndexOf(ByVal value As PasswordData) As Integer
        Return Me._items.IndexOf(value)
    End Function


    Private Sub Insert(ByVal index As Integer, ByVal value As Object) Implements System.Collections.IList.Insert

    End Sub

    Public Sub Insert(ByVal index As Integer, ByVal value As PasswordData)
        Me._items.Insert(index, value)
    End Sub

    Public ReadOnly Property IsFixedSize() As Boolean Implements System.Collections.IList.IsFixedSize
        Get
            Return Me._items.IsFixedSize
        End Get
    End Property

    Public ReadOnly Property IsReadOnly() As Boolean Implements System.Collections.IList.IsReadOnly
        Get
            Return Me._items.IsReadOnly
        End Get
    End Property

    Private Property Item1(ByVal index As Integer) As Object Implements System.Collections.IList.Item
        Get
            Return Me._items(index)
        End Get
        Set(ByVal value As Object)
            Me._items(index) = value
        End Set
    End Property

    Default Public Property Item(ByVal index As Integer) As PasswordData
        Get
            Return DirectCast(Me._items(index), PasswordData)
        End Get
        Set(ByVal value As PasswordData)
            Me._items(index) = value
        End Set
    End Property

    Public Sub Remove(ByVal value As Object) Implements System.Collections.IList.Remove
        Me._items.Remove(value)
    End Sub

    Public Sub RemoveAt(ByVal index As Integer) Implements System.Collections.IList.RemoveAt
        Me._items.RemoveAt(index)
    End Sub

    Public Sub RemoveRecord(ByVal RecordId As Integer)

        For Each item As Object In Me._items
            If DirectCast(item, PasswordData).RecordId = RecordId Then
                Me._items.Remove(item)
                Exit For
            End If
        Next

    End Sub

    Public Function GetRecord(ByVal RecordId As Integer) As PasswordData

        For Each item As Object In Me._items
            If DirectCast(item, PasswordData).RecordId = RecordId Then Return DirectCast(item, PasswordData)
        Next

        Return Nothing

    End Function

End Class

Public Class PasswordData

    Dim _recId As Integer
    Dim _descr As String
    Dim _lgid As String
    Dim _pwd As String
    Dim _webSite As String
    Dim _notes As String
    Dim _category As Integer

    Public Sub New()
        _recId = -1
        _descr = ""
        _lgid = ""
        _pwd = ""
        _webSite = ""
        _notes = ""
        _category = -1
    End Sub

    Public Sub New(ByVal RecId As Integer, ByVal Descr As String, ByVal LgId As String, ByVal Pwd As String, ByVal WSite As String, ByVal Nts As String, ByVal Categ As Integer)
        _recId = RecId
        _descr = Descr
        _lgid = LgId
        _pwd = Pwd
        _webSite = WSite
        _notes = Nts
        _category = Categ
    End Sub

    Public Property RecordId() As Integer
        Get
            Return Me._recId
        End Get
        Set(ByVal value As Integer)
            Me._recId = value
        End Set
    End Property

    Public Property Description() As String
        Get
            Return Me._descr
        End Get
        Set(ByVal value As String)
            Me._descr = value
        End Set
    End Property

    Public Property LoginId() As String
        Get
            Return Me._lgid
        End Get
        Set(ByVal value As String)
            Me._lgid = value
        End Set
    End Property

    Public Property Password() As String
        Get
            Return Me._pwd
        End Get
        Set(ByVal value As String)
            Me._pwd = value
        End Set
    End Property

    Public Property WebSite() As String
        Get
            Return Me._webSite
        End Get
        Set(ByVal value As String)
            Me._webSite = value
        End Set
    End Property

    Public Property Notes() As String
        Get
            Return Me._notes
        End Get
        Set(ByVal value As String)
            Me._notes = value
        End Set
    End Property

    Public Property Category() As Integer
        Get
            Return Me._category
        End Get
        Set(ByVal value As Integer)
            Me._category = value
        End Set
    End Property

End Class