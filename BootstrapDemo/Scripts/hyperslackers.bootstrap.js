function ReBindModalCKEditors() {
    $(document).ready(function () {
        $('.modal textarea.ckeditor').each(function () {
            var hEd = CKEDITOR.instances[this.id];
            if (hEd) {
                CKEDITOR.remove(hEd);
                CKEDITOR.replace(this.id);
            } else {
                CKEDITOR.replace(this.id);
            }
        });
    });
}

function BindElements() {
    $(document).ready(function () {

        // tooltips and popovers
        $('[rel=tooltip]').tooltip();
        $('[rel=popover]').popover();
        $('[data-toggle="tooltip"]').tooltip();
        $('[data-toggle="popover"]').popover();

        // datepicker
        $('.datepicker').datepicker();
        $('.input-group.date').datepicker();

        // typeahead
        $(function () {
            $('[data-provide=typeahead]').each(function () {
                var self = $(this);
                self.typeahead({
                    source: function (term, process) {
                        var url = self.data('url');

                        return $.getJSON(url, { term: term }, function (data) {
                            return process(data);
                        });
                    }
                });
            });

            $('[data-disabled-depends-on]').each(function () {
                var self = $(this);
                var name = self.data('disabled-depends-on');
                var val = self.data('disabled-depends-val');
                var selector = '[name="' + name + '"]';

                $(document).on('change', selector + ':checkbox', function () {
                    self.prop('disabled', $(this).prop('checked') == val);
                });

                $(document).on('change', selector + ':not(:checkbox):not(:hidden)', function () {
                    self.prop('disabled', $(this).val() == val);
                });
                $(selector).change();
            });

            var isFirstRun = true;
            $('[data-visible-depends-on]').each(function () {
                var self = $(this);
                var name = self.data('visible-depends-on');
                var val = self.data('visible-depends-val');
                var speed = self.data('visible-depends-speed');
                var selector = '[name="' + name + '"]';
                var selfName = self.attr('name');
                var toHide;

                if (self.is('div')) {
                    toHide = self;
                } else {
                    var formGroup = self.closest('.form-group');
                    if (formGroup.length > 0 && formGroup.find('input:not(:hidden):not([name="' + selfName + '"]),select:not([name="' + selfName + '"]),textarea:not([name="' + selfName + '"])').length === 0) {
                        toHide = formGroup;
                    } else {
                        toHide = $('[name="' + selfName + '"],label[for="' + selfName + '"]');
                    }
                }

                $(document).on('change', selector + ':checkbox', function () {
                    if ($(this).prop('checked') == val) {
                        toHide.show(isFirstRun ? undefined : speed);
                    } else {
                        toHide.hide(isFirstRun ? undefined : speed);
                    }
                });

                $(document).on('change', selector + ':not(:checkbox):not(:hidden)', function () {
                    if ($(this).val() == val) {
                        toHide.show(isFirstRun ? undefined : speed);
                    } else {
                        toHide.hide(isFirstRun ? undefined : speed);
                    }
                });

                if ($(selector).is(':radio')) {
                    $(selector + ':checked').change();
                } else {
                    $(selector).change();
                }
                isFirstRun = false;
            });
        });
    });
}

function BindModalElements() {
    $(document).ready(function () {
        $('.modal form').each(function () {
            // enable unobtrusive validation for the contents
            // that was injected into the <div id="result"></div> node
            $.validator.unobtrusive.parse($(this));
            // make client-side validation look the same as server-side one
            $('form').bind('invalid-form.validate', function (form) {
                $('.validation-summary-errors').parent().addClass('alert alert-danger').find('.close').show();
            });
        });

        BindElements();

        ReBindModalCKEditors();
    });
}

$(document).ready(function () {

    // popover close button
    // TODO: is this right? seems too broad of a selector
    $(document).on('click', '.close', function () {
        $(this).closest('.popover').prev('[data-toggle="popover"]').popover('hide');
    });

    // tree-toggle
    $(document).on('click', 'label.tree-toggle', function () {
        $(this).parent().children('ul.tree').toggle(300);
        $(this).parent().children('i').toggleClass('fa-plus-square fa-minus-square', 300);
    });
    $(document).on('click', 'i.tree-toggle', function () {
        $(this).parent().children('ul.tree').toggle(300);
        $(this).parent().children('i').toggleClass('fa-plus-square fa-minus-square', 300);
    });
    $(document).on('click', 'ul.tree-toggle', function () {
        $(this).children('ul.tree').toggle(300);
        $(this).children('i').toggleClass('fa-plus-square fa-minus-square', 300);
    });

    // validation
    if ($.validator) {
        $.validator.setDefaults({
            highlight: function (element) {
                $(element).closest(".control-group").addClass("error");
                $(element).closest(".form-group").addClass("has-error");
            },
            unhighlight: function (element) {
                $(element).closest(".control-group").removeClass("error");
                $(element).closest(".form-group").removeClass("has-error");
            }
        });
    }
    $('form').bind('invalid-form.validate', function (form) {
        $('.validation-summary-errors').parent().addClass('alert alert-danger').find('.close').show();
        $('.validation-summary-valid').parent().addClass('alert alert-danger').find('.close').show();
    });

    // modal - re-usable
    $('body').on('hidden.bs.modal', function (e) {
        if ($(e.target).attr('data-refresh') == 'true') {
            // Remove modal data
            $(e.target).removeData('bs.modal').find(".modal-content").empty();
            // Empty the HTML of modal
            //$(e.target).html('');
        }
    });

    // modal - refresh main page
    $('body').on('hidden.bs.modal', '.modal', function (e) {
        if ($(e.target).attr('reload-page') == 'true') {
            document.location.reload();
        }
    });

    // modal - loaded
    $('body').on('loaded.bs.modal', '.modal', function (e) {
        // enable unobtrusive validation for the contents
        // that was injected into the <div id="result"></div> node
        $.validator.unobtrusive.parse($(e.target));
        // make client-side validation look the same as server-side one
        $('form').bind('invalid-form.validate', function (form) {
            $('.validation-summary-errors').parent().addClass('alert alert-danger').find('.close').show();
        });
        //$('[data-toggle="tooltip"]').tooltip();
        //$('[data-toggle="popover"]').popover();
        //$('#WhatsNew').ckeditor();
        //CKEDITOR.replace('WhatsNew');
        //$('.datepicker').datepicker();
        //$('.input-group.date').datepicker();

        //$(document).ajaxComplete(function () {
        //    ReBindModalCKEditors();
        //});
    });

    // modal - shown
    $('body').on('shown.bs.modal', '.modal', function (e) {
        //setTimeout(ReBindModalCKEditors(), 500);

        // enable unobtrusive validation for the contents
        // that was injected into the <div id="result"></div> node
        $.validator.unobtrusive.parse($(e.target));
        // make client-side validation look the same as server-side one
        $('form').bind('invalid-form.validate', function (form) {
            $('.validation-summary-errors').parent().addClass('alert alert-danger').find('.close').show();
        });
    });

    // modal - hide
    $('body').on('hide.bs.modal', '.modal', function (e) {
        $('.modal textarea.ckeditor').each(function () {
            var hEd = CKEDITOR.instances[this.id];
            if (hEd) {
                CKEDITOR.remove(hEd);
            }
        })
    });

    // ajax - 
    $(document).ajaxComplete(function () {
        BindModalElements();
    });

    BindElements();
});


